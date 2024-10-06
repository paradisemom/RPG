using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed=2f;
    Rigidbody2D rb;
    Vector2 MoveDir;
    KnockBack knockBack;
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        knockBack=GetComponent<KnockBack>();
        rb=GetComponent<Rigidbody2D>();
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        if(knockBack.gettingKnockedBack){return;}
        rb.MovePosition(rb.position+MoveDir*(moveSpeed*Time.fixedDeltaTime));
        if(MoveDir.x<0){
            spriteRenderer.flipX=true;
        }else
        {
            spriteRenderer.flipX=false;
        }
    }
    public void MoveTo(Vector2 targetPosition){
        MoveDir=targetPosition;
    }
    public void StopMoving(){
        MoveDir= Vector3.zero;
    }
}
