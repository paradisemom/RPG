using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public bool gettingKnockBack{get; private set;}
    [SerializeField]private float knockBackTime=0.2f;
    private Rigidbody2D rb;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    public void GetKonckBack(Transform damageSource,float knockBackTrust){
        gettingKnockBack=true;
        Vector2 difference=(transform.position-damageSource.position).normalized*knockBackTrust*rb.mass;
        rb.AddForce(difference,ForceMode2D.Impulse);
        StartCoroutine(KnockRoutine());
    }
    private IEnumerator KnockRoutine(){
        yield return new WaitForSeconds(knockBackTime);
        rb.velocity=Vector2.zero;
        gettingKnockBack=false;
    }
}
