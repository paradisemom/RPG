using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFade : MonoBehaviour
{
    [SerializeField]private float FadeTime=.4f;
    private SpriteRenderer spriteRenderer;
    private void Awake() {
        spriteRenderer=GetComponent<SpriteRenderer>();
    }
    public IEnumerator SlowFadeRoutine(){
        float elapsedTime=0;
        float startValue=spriteRenderer.color.a;
        while (elapsedTime<FadeTime)
        {
            elapsedTime+=Time.deltaTime;
            float newAlpha=Mathf.Lerp(startValue,0f,elapsedTime/FadeTime);
            spriteRenderer.color=new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,newAlpha);
            yield return null;
        }
        Destroy(gameObject);
    }
}
