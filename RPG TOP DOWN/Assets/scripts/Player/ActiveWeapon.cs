using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : SingleTon<ActiveWeapon>
{
    public MonoBehaviour CurrentActiveWeapon{get;private set;}
    private PlayerControls playerControls;
    private float timeBetweenAttacks;
    private bool attackButtonDown,isAttacking=false;

    protected override void Awake() {
        base.Awake();

        playerControls=new PlayerControls();
    }
    private void OnEnable() {
        playerControls.Enable();
    }
    private void Start() {
        playerControls.Combat.Attack.started+= _ =>StartAttack();
        playerControls.Combat.Attack.canceled+= _ =>StopAttack();

        AttackCoolDown();
    }
    private void Update() {
        Attack();
    }
    public void NewWeapon(MonoBehaviour newWeapon){
        CurrentActiveWeapon=newWeapon;

        AttackCoolDown();
        timeBetweenAttacks=(CurrentActiveWeapon as IWeapon).GetWeaponInfo().weaponCoolDdwn;
    }
    public void WeaponNull(){
        CurrentActiveWeapon=null;
    }
    private void AttackCoolDown(){
        isAttacking=true;
        StopAllCoroutines();
        StartCoroutine(TimeBetweenAttacksRoutine());
    }
    private IEnumerator TimeBetweenAttacksRoutine(){
        yield return new WaitForSeconds(timeBetweenAttacks);
        isAttacking=false;
    }
    
    private void StartAttack(){
        attackButtonDown=true;
    }
    private void StopAttack(){
        attackButtonDown=false;
    }
    private void Attack(){
        if(attackButtonDown&&!isAttacking&&CurrentActiveWeapon){
            AttackCoolDown();
            (CurrentActiveWeapon as IWeapon).Attack();
        }
    }
}
