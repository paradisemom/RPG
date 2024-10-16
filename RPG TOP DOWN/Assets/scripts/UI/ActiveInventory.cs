using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ActiveInventory : MonoBehaviour
{
    private int activeSlotIndexNum=0;
    private PlayerControls playerControls;
    private void Awake() {
        playerControls=new PlayerControls();
    }
    private void Start() {
        playerControls.Inventory.Keyboard.performed+= ctx=>ToggleAvctiveSlot((int)ctx.ReadValue<float>());

        ToggleActiveHeighLight(0);
    }
    private void OnEnable() {
        playerControls.Enable();
    }
    private void ToggleAvctiveSlot(int numValue){
        ToggleActiveHeighLight(numValue-1);
    }
    private void ToggleActiveHeighLight(int indexNum){
        activeSlotIndexNum=indexNum;

        foreach (Transform inventorySlot in this.transform)
        {   
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }
        this.transform.GetChild(indexNum).GetChild(0).gameObject.SetActive(true);

        ChangeActiveWeapon();
    }
    private void ChangeActiveWeapon(){
        if(ActiveWeapon.Instance.CurrentActiveWeapon!=null){
            Destroy(ActiveWeapon.Instance.CurrentActiveWeapon.gameObject);
        }
        Transform childTransform=transform.GetChild(activeSlotIndexNum);
        InventorySlot inventorySlot=childTransform.GetComponentInChildren<InventorySlot>();
        WeaponInfo weaponInfo=inventorySlot.GetWeaponInfo();
        GameObject weaponToSpawn=weaponInfo.weaponPrefab;
        GameObject newWeapon=Instantiate(weaponToSpawn,ActiveWeapon.Instance.transform.position,Quaternion.identity);
        ActiveWeapon.Instance.transform.rotation=Quaternion.Euler(0,0,0);
        newWeapon.transform.parent=ActiveWeapon.Instance.transform;
        ActiveWeapon.Instance.NewWeapon(newWeapon.GetComponent<MonoBehaviour>());
    }
}

