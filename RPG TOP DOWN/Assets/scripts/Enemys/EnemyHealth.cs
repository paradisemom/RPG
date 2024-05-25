using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]private int startingHealth=3;
    [SerializeField]private GameObject deathVFXPrefab;
    KnockBack knockBack;
    Flash flash;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        flash=GetComponent<Flash>();
        knockBack=GetComponent<KnockBack>();
    }

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
        knockBack.GetKonckBack(PlayerController.Instance.transform,15f);
        StartCoroutine(flash.FlashRoutine());
    }

    public void DetectDeath()
    {
        if(currentHealth<=0){
            Instantiate(deathVFXPrefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
