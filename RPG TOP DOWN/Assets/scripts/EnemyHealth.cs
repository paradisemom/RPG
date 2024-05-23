using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]private int startingHealth=3;

    private int currentHealth;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        currentHealth=startingHealth;
    }
    public void TakeDamage(int damage){
        currentHealth-=damage;
        Debug.Log(currentHealth);
        DetectHealth();
    }

    private void DetectHealth()
    {
        if(currentHealth<=0){
            Destroy(gameObject);
        }
    }
}
