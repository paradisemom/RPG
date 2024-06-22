using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ActiveInventory : MonoBehaviour
{
    private float activeSlotIndexNum=0;
    private PlayerControls playerControls;
    private void Awake() {
        playerControls=new PlayerControls();
    }
    private void Start() {
        playerControls.Inventory.Keyboard.performed+= ctx=>ToggleAvctiveSlot((int)ctx.ReadValue<float>());
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
        Debug.Log(transform.GetChild((int)activeSlotIndexNum).GetComponent<InventorySlot>().GetWeaponInfo().weaponPrefab.name);
    }
}

