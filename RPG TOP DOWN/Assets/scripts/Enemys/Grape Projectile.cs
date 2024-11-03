using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeProjectile : MonoBehaviour
{
    [SerializeField] private float duration=1f;
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private float heightY=3f;
    [SerializeField] private GameObject grapeProjectileShadow;
    private void Start() {
        GameObject grapeShadow=
        Instantiate(grapeProjectileShadow,transform.position+new Vector3(0,-3f,0),Quaternion.identity);
        Vector3 playerPos=PlayerController.Instance.transform.position;
        Vector3 grapeShadowStartPos=grapeShadow.transform.position;

        StartCoroutine(ProjectileCurveRoutine(transform.position,playerPos));
        StartCoroutine(MoveGrapeShadowRoutine(grapeShadow,grapeShadowStartPos,playerPos));
    }
    private IEnumerator ProjectileCurveRoutine(Vector3 startPos,Vector3 endPos){
        float timePass=0f;
        while(timePass<duration){
            timePass+=Time.deltaTime;
            float linerT=timePass/duration;
            float heightT=animCurve.Evaluate(linerT);
            float height=Mathf.Lerp(0,heightY,heightT);

            transform.position=Vector2.Lerp(startPos,endPos,linerT)+new Vector2(0f,height);

            yield return null;
        }
        Destroy(gameObject);
    }
    private IEnumerator MoveGrapeShadowRoutine(GameObject grapeShadow,Vector3 startPos,Vector3 endPos){
        float timePass=0f;
        while(timePass<duration){
            timePass+=Time.deltaTime;
            float linerT=timePass/duration;
            grapeShadow.transform.position=Vector2.Lerp(startPos,endPos,linerT);
            yield return null;
        }
        Destroy(grapeShadow);
    }

}
