
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private enum PickUPType{
        GoldCoin,
        HealthGlobe,
        StaminaGlobe,
    }
    [SerializeField] private PickUPType pickUPType;
    [SerializeField] private float pickUpDistance=5f;
    [SerializeField] private float accelartionRate=.3f;
    [SerializeField] private float moveSpeed=6f;
    [SerializeField] private AnimationCurve animationCurve;
    // [SerializeField] private float highY=1.5f;
    [SerializeField] private float popDuration=1f;
    private Vector3 moveDir;
    private Rigidbody2D rb;
    private void Awake() {
        rb=GetComponent<Rigidbody2D>();
    }
    private void Start() {
        StartCoroutine(AnimCurveSpawnRoutine());
    }
    private void Update() {
        Vector3 playerPos=PlayerController.Instance.transform.position;

        if(Vector3.Distance(playerPos,transform.position)<pickUpDistance){
            moveDir=(playerPos-transform.position).normalized;
            moveSpeed+=accelartionRate;
        }else{
            moveDir=Vector3.zero;
            moveSpeed=0;
        }

        

    }
    private void FixedUpdate() {
        rb.velocity=moveDir*moveSpeed*Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerController>()){
            DetectPickUpType();
            Destroy(gameObject);
        }
        
    }
    private IEnumerator AnimCurveSpawnRoutine(){
        Vector2 startPoint=transform.position;
        float randomX=transform.position.x+Random.Range(-2f,2f);
        float randomY=transform.position.y+Random.Range(-1f,1f);

        Vector2 endPoint=new Vector2(randomX,randomY);

        float timePassed=0f;
        while (timePassed<popDuration)
        {   
            timePassed+=Time.deltaTime;
            float linearT=timePassed/popDuration;
            float heightT=animationCurve.Evaluate(linearT);
            float height=Mathf.Lerp(0f,linearT,heightT);

            transform.position=Vector2.Lerp(startPoint,endPoint,linearT)+new Vector2(0f,height);
            yield return null;
        }
    }   
    private void DetectPickUpType(){
        switch (pickUPType){
            case PickUPType.GoldCoin:
                //do coin stuff
                Debug.Log("goldcoin");
                break;
            case PickUPType.HealthGlobe:
                PlayerHealth.Instance.HealthPlayer();
                Debug.Log("health");
                break;
            case PickUPType.StaminaGlobe:
                //do stamina stuff
                Debug.Log("Stamina");
                break;
        }
    }
}
