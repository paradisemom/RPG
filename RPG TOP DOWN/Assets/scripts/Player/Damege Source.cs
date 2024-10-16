using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamegeSource : MonoBehaviour
{
    private int damageAmount;
    private EnemyHealth enemyHealth;
    private Projettile projettile;
    private void Start() {
        MonoBehaviour currentActiveWeapon=ActiveWeapon.Instance.CurrentActiveWeapon;
        damageAmount=(currentActiveWeapon as IWeapon).GetWeaponInfo().weaponDamage;
    }
    private void  OnTriggerEnter2D(Collider2D other) {
            EnemyHealth enemyHealth=other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damageAmount); 
                 
    }
}
