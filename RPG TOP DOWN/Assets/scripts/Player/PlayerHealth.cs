using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : SingleTon<PlayerHealth>
{
    public bool isDead {get;private set;}
    [SerializeField]private int maxHealth=3;
    [SerializeField]private float knockBackThrustAmount=10f;
    [SerializeField]private float damageRecoveryTime=1f;

    private Slider healthSlider;
    private int currentHealth;
    private bool canTakeDamage=true;
    private KnockBack knockBack;
    private Flash flash;
    const string HEALTH_SLIDE_TEXT = "HeartSlider";
    const string TOWN_TEXT="Scene 1";
    readonly int DEATH_HASH=Animator.StringToHash("Death");
    
    protected override void Awake(){
        base.Awake();
        flash=GetComponent<Flash>();
        knockBack=GetComponent<KnockBack>();
    }
    private void Start() {
        isDead=false;
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
        if(currentHealth<=0&&!isDead){
            isDead=true;
            Destroy(ActiveWeapon.Instance.gameObject);
            currentHealth=0;
            GetComponent<Animator>().SetTrigger(DEATH_HASH);
            StartCoroutine(DeathLoadSceneRoutine());
        }
    }
    private IEnumerator DeathLoadSceneRoutine(){
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        SceneManager.LoadScene(TOWN_TEXT);
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
