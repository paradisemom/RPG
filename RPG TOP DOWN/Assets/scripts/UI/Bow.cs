using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bow : MonoBehaviour,IWeapon
{
    [SerializeField]private WeaponInfo weaponInfo;
    [SerializeField]private GameObject arrowPrefab;
    [SerializeField]private Transform arrowSpawnPoint;
    readonly int FIRE_HASH=Animator.StringToHash("Fire");
    private Animator myAnimator;

    private void Awake() {
        myAnimator=GetComponent<Animator>();
    }
    public void Attack(){
        myAnimator.SetTrigger("Fire");
        GameObject newArrow=Instantiate(arrowPrefab,arrowSpawnPoint.position,ActiveWeapon.Instance.transform.rotation);
        newArrow.GetComponent<Projectile>().UpdateProjectileRange(weaponInfo.weaponRange);
    }
    public WeaponInfo GetWeaponInfo(){
        return weaponInfo;
    }

}
