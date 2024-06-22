using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : SingleTon<ActiveWeapon>
{
    [SerializeField] private MonoBehaviour currentActiveWeapon;
    private PlayerControls playerControls;
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
    }
    private void Update() {
        Attack();
    }
    public void ToggleIsAttacking(bool value){
        isAttacking=value;
    }
    private void StartAttack(){
        attackButtonDown=true;
    }
    private void StopAttack(){
        attackButtonDown=false;
    }
    private void Attack(){
        if(attackButtonDown&&!isAttacking){
            isAttacking=true;
            (currentActiveWeapon as IWeapon).Attack();
        }
    }
}
