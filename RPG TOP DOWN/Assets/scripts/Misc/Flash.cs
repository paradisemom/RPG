using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material whiteFlashMat;
    [SerializeField] private float restoreDfaultMatTime=.2f;

    private Material defaultMat;
    private SpriteRenderer spriteRenderer;
    private EnemyHealth enemyHealth;
    private void Awake() {
        enemyHealth=GetComponent<EnemyHealth>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        defaultMat=spriteRenderer.material;
    }
    public IEnumerator FlashRoutine(){
        spriteRenderer.material=whiteFlashMat;
        yield return new WaitForSeconds(restoreDfaultMatTime);
        spriteRenderer.material=defaultMat;
        enemyHealth.DetectDeath();
    }
}
