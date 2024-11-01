using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingleTon<PlayerController>
{
    public bool FacingLeft{get{return facingLeft;}}

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float dashSpeed=4f;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private Transform weaponCollider;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private KnockBack knockBack;
    Animator myanimator;
    SpriteRenderer myspriteRenderer;
    private float startingMoveSpeeed;
    private bool facingLeft=false;
    private bool isDashing=false;
    protected override void Awake(){
        base.Awake();
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myspriteRenderer=GetComponent<SpriteRenderer>();
        myanimator=GetComponent<Animator>();
        knockBack=GetComponent<KnockBack>();
    }
    private void Start() {
        playerControls.Combat.Dash.performed+= _ =>Dash();
        startingMoveSpeeed=moveSpeed;
    }


    private void OnEnable() {
        playerControls.Enable();
    }

    private void Update() {
        PlayerInput();
    }

    private void FixedUpdate() {
        AdjustPalyerFacingDirection();
        Move();
    }

    private void PlayerInput() {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        myanimator.SetFloat("moveX",movement.x);
        myanimator.SetFloat("moveY",movement.y);
    }
    public Transform GetWeaponCollider(){
        return weaponCollider;
    }

    private void Move() {
        if(knockBack.gettingKnockedBack){return;}
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
    private void AdjustPalyerFacingDirection(){
        Vector3 mousepos=Input.mousePosition;
        Vector3 playerScreenPoint=Camera.main.WorldToScreenPoint(transform.position);
        if(mousepos.x<playerScreenPoint.x){
            myspriteRenderer.flipX=true;
            facingLeft=true;
        }else {
            myspriteRenderer.flipX=false;
            facingLeft=false;
        }
    }
    private void Dash(){
        if(!isDashing&&Stamina.Instance.currentStamina>0){
            Stamina.Instance.useStamina();
            isDashing=true;
            moveSpeed *=dashSpeed;
            trailRenderer.emitting=true;
            StartCoroutine(EndDashRoutine());
        }
    }
    private IEnumerator EndDashRoutine(){
        float dashTime=.2f;
        float dashCD=.25f;
        yield return new WaitForSeconds(dashTime);
        moveSpeed=startingMoveSpeeed;
        trailRenderer.emitting=false;
        yield return new WaitForSeconds(dashCD);
        isDashing=false;
    }
}
