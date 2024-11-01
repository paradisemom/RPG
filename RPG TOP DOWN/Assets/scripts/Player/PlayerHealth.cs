using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : SingleTon<PlayerHealth>
{
    [SerializeField]private int maxHealth=3;
    [SerializeField]private float knockBackThrustAmount=10f;
    [SerializeField]private float damageRecoveryTime=1f;

    private Slider healthSlider;
    private int currentHealth;
    private bool canTakeDamage=true;
    private KnockBack knockBack;
    private Flash flash;
    const string HEALTH_SLIDE_TEXT = "HeartSlider";
    
    protected override void Awake(){
        base.Awake();
        flash=GetComponent<Flash>();
        knockBack=GetComponent<KnockBack>();
    }
    private void Start() {
        currentHealth=maxHealth;
        UpdateHealthSlider();
    }
    public void HealthPlayer(){
        if(currentHealth<maxHealth){
            currentHealth+=1;
            UpdateHealthSlider();
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        EnemyAI enemi=other.gameObject.GetComponent<EnemyAI>();

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
        UpdateHealthSlider();
        CheckIfPlayerDeath();
    }
    private void CheckIfPlayerDeath(){
        if(currentHealth<=0){
            currentHealth=0;
            Debug.Log("Death");
        }
    }
    private IEnumerator DamageRecoveryRoutine(){
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage=true;
    }
    private void UpdateHealthSlider(){
        if(healthSlider==null){
            healthSlider=GameObject.Find(HEALTH_SLIDE_TEXT).GetComponent<Slider>();
        }
        healthSlider.maxValue=maxHealth;
        healthSlider.value=currentHealth;
    }
}
