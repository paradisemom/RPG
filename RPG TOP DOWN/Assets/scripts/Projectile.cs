using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projettile : MonoBehaviour
{
    [SerializeField]private float moveSpeed=22f;
    [SerializeField]private GameObject particleOnHitPrefabVFX;

    private WeaponInfo weaponInfo;
    private Vector3 startPosition;
    private void Update() {
        MoveProjectile();
        DetectFireDistance();
    }
    public void UpdateWeaponInfo(WeaponInfo weaponInfo){
        this.weaponInfo=weaponInfo;
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemyHealth=other.gameObject.GetComponent<EnemyHealth>();
        indestroctible inDestroctible=other.gameObject.GetComponent<indestroctible>();

        if(!other.isTrigger&&(enemyHealth||inDestroctible)){
            enemyHealth?.TakeDamage(weaponInfo.weaponDamage);
            Instantiate(particleOnHitPrefabVFX,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
    private void DetectFireDistance(){
        if(Vector3.Distance(transform.position,startPosition)>weaponInfo.weaponRange){
            Destroy(gameObject);
        }
    }
    private void MoveProjectile(){
        transform.Translate(Vector3.right*Time.deltaTime*moveSpeed);
    }
}
