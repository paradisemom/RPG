using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]private int startingHealth=3;
    [SerializeField]private GameObject deathVFXPrefab;
    [SerializeField]private float knockBackTrust=15f;
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
        ScreenShakeManager.Instance.ShakeScreen();
        knockBack.GetKonckBack(PlayerController.Instance.transform,knockBackTrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeath());
    }
    private IEnumerator CheckDetectDeath(){
        yield return new WaitForSeconds(flash.GetRestoreTime());
        DetectDeath();
    }
    public void DetectDeath()
    {
        if(currentHealth<=0){
            Instantiate(deathVFXPrefab,transform.position,Quaternion.identity);
            GetComponent<PickUpSpawner>().BossDropItems();
            Destroy(gameObject);
        }
    }
}
