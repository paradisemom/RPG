using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Transprant : MonoBehaviour
{
    [Range(0,1)]
    [SerializeField]private float transparencyAmount=.8f;
    [SerializeField]private float fadeTime=.4f;

    private SpriteRenderer spriteRenderer;
    private Tilemap tilemap;
    private void Awake() {
        spriteRenderer=GetComponent<SpriteRenderer>();
        tilemap=GetComponent<Tilemap>();
    }
    private void  OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerController>()){
            if(spriteRenderer){
                StartCoroutine(FadeRoutine(spriteRenderer,fadeTime,spriteRenderer.color.a,transparencyAmount));
            }else if(tilemap){
                StartCoroutine(FadeRoutine(tilemap,fadeTime,tilemap.color.a,transparencyAmount));
            }
        }
    }
    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>()){
            if(spriteRenderer){
                StartCoroutine(FadeRoutine(spriteRenderer,fadeTime,spriteRenderer.color.a,1f));
            }else if(tilemap){
                StartCoroutine(FadeRoutine(tilemap,fadeTime,tilemap.color.a,1f));
            }
        }
    }
    private IEnumerator FadeRoutine(SpriteRenderer spriteRenderer,float fadeTime,float startvalue,float targetTransparency){
        float elapsedTime=0;
        while(elapsedTime<fadeTime){
            elapsedTime+=fadeTime;
            float newAlpha=Mathf.Lerp(startvalue,targetTransparency,elapsedTime/fadeTime);
            spriteRenderer.color=new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,newAlpha);
            yield return null;
        }
    }
    private IEnumerator FadeRoutine(Tilemap tilemap,float fadeTime,float startvalue,float targetTransparency){
        float elapsedTime=0;
        while(elapsedTime<fadeTime){
            elapsedTime+=Time.deltaTime;
            float newAlpha=Mathf.Lerp(startvalue,targetTransparency,elapsedTime/fadeTime);
            tilemap.color=new Color(tilemap.color.r,tilemap.color.g,tilemap.color.b,newAlpha);
            yield return null;
        }
    }
        
    
}
