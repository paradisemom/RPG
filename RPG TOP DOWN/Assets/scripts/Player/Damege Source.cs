using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamegeSource : MonoBehaviour
{
    [SerializeField]private int damageAmount=1;
    private void  OnTriggerEnter2D(Collider2D other) {
            EnemyHealth enemyHealth=other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damageAmount);       
    }
}
