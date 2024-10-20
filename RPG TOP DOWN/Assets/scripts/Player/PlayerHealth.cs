using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : SingleTon<PlayerHealth>
{
    [SerializeField]private int maxHealth=3;
    [SerializeField]private float knockBackThrustAmount=10f;
    [SerializeField]private float damageRecoveryTime=1f;

    private int currentHealth;
    private bool canTakeDamage=true;
    private KnockBack knockBack;
    private Flash flash;
    protected override void Awake(){
        base.Awake();
        flash=GetComponent<Flash>();
        knockBack=GetComponent<KnockBack>();
    }
    private void Start() {
        currentHealth=maxHealth;
    }
    public void HealthPlayer(){
        currentHealth+=1;
    }
    private void OnCollisionStay2D(Collision2D other) {
        EnemiAI enemi=other.gameObject.GetComponent<EnemiAI>();

        if(enemi){TakeDamage(1,other.transform);}
    }
    public void TakeDamage(int damageAmount,Transform hitTransform){
        
        if(!canTakeDamage){return;}
        ScreenShakeManager.Instance.ShakeScreen();
        knockBack.GetKonckBack(hitTransform,knockBackThrustAmount);
        StartCoroutine(flash.FlashRoutine());
        canTakeDamage=false;
        currentHealth-=damageAmount;
        StartCoroutine(DamageRecoveryRoutine());
    }
    private IEnumerator DamageRecoveryRoutine(){
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage=true;
    }
}
