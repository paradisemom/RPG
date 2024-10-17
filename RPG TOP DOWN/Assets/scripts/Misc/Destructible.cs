using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<DamegeSource>()||other.gameObject.GetComponent<Projettile>()){
            GetComponent<PickUpSpawner>().DrapItems();
            Instantiate(destroyVFX,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}  
