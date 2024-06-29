using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<DamegeSource>()||other.gameObject.GetComponent<Projettile>()){
            Instantiate(destroyVFX,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
