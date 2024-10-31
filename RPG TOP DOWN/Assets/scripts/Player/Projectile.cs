using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]private float moveSpeed=22f;
    [SerializeField]private GameObject particleOnHitPrefabVFX;
    [SerializeField]private bool isEnemyProjectile=false;
    [SerializeField]private float projectileRange=10f;


    private Vector3 startPosition;
    private void Start() {
        startPosition=transform.position;
    }
    private void Update() {
        MoveProjectile();
        DetectFireDistance();
    }
    public void UpdateProjectileRange(float projectileRange){
        this.projectileRange=projectileRange;
    }
    public void UpdateMoveSpeed(float moveSpeed){
        this.moveSpeed=moveSpeed;
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemyHealth=other.gameObject.GetComponent<EnemyHealth>();
        Indestroctible inDestroctible=other.gameObject.GetComponent<Indestroctible>();
        PlayerHealth player=other.gameObject.GetComponent<PlayerHealth>();
        
        if(!other.isTrigger&&(enemyHealth||inDestroctible||player)){
            if((player&&isEnemyProjectile)){
                Instantiate(particleOnHitPrefabVFX,transform.position,transform.rotation);
                player?.TakeDamage(1,transform);
                Destroy(gameObject);           
            }
            if(inDestroctible){
                Instantiate(particleOnHitPrefabVFX,transform.position,transform.rotation);
                Destroy(gameObject);
            }
            
        }

            
        
    }

    private void DetectFireDistance(){
        if(Vector3.Distance(transform.position,startPosition)>projectileRange){
            Destroy(gameObject);
        }
    }
    private void MoveProjectile(){
        transform.Translate(Vector3.right*Time.deltaTime*moveSpeed);
    }
}
