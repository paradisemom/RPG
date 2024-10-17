using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private float pickUpDistance=5f;
    [SerializeField] private float accelartionRate=.3f;
    [SerializeField] private float moveSpeed=6f;
    private Vector3 moveDir;
    private Rigidbody2D rb;
    private void Awake() {
        rb=GetComponent<Rigidbody2D>();
    }
    private void Update() {
        Vector3 playerPos=PlayerController.Instance.transform.position;

        if(Vector3.Distance(playerPos,transform.position)<pickUpDistance){
            moveDir=(playerPos-transform.position).normalized;
            moveSpeed+=accelartionRate;
        }else{
            moveDir=Vector3.zero;
            moveSpeed=0;
        }

        

    }
    private void FixedUpdate() {
        rb.velocity=moveDir*moveSpeed*Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerController>()){
            Destroy(gameObject);
        }
        
    }
}
