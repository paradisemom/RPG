using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool FacingLeft{get{return facingLeft;}set {facingLeft=value;}}
    public static PlayerController Instance;
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    Animator myanimator;
    SpriteRenderer myspriteRenderer;
    private bool facingLeft=false;
    private void Awake() {
        Instance=this;
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myspriteRenderer=GetComponent<SpriteRenderer>();
        myanimator=GetComponent<Animator>();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void Update() {
        PlayerInput();
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            moveSpeed=8f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            moveSpeed=4f;
        }
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

    private void Move() {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
    private void AdjustPalyerFacingDirection(){
        Vector3 mousepos=Input.mousePosition;
        Vector3 playerScreenPoint=Camera.main.WorldToScreenPoint(transform.position);
        if(mousepos.x<playerScreenPoint.x){
            myspriteRenderer.flipX=true;
            FacingLeft=true;
        }else {
            myspriteRenderer.flipX=false;
            FacingLeft=false;
        }
    }
}
