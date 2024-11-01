using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Stamina : SingleTon<Stamina>
{
    public int currentStamina{get;private set;}
    
    [SerializeField] private Sprite fullStaminaImage,emptyStaminaImage;
    [SerializeField] private int timeBetweenStaminaRefresh=3;

    private Transform staminaContainer;
    private int startStamina=3;
    private int maxStamina;
    const string STAMINA_CONTANIER_NAME = "Stamina Container";
    protected override void Awake()
    {
        base.Awake();

        maxStamina=startStamina;
        currentStamina=startStamina;
    }
    private void Start() {
        staminaContainer=GameObject.Find(STAMINA_CONTANIER_NAME).transform;
    }
    public void useStamina(){
        currentStamina--;
        UpdateStaminaImage();
    }
    public void RefreshStamina(){
        if(currentStamina<maxStamina){
            currentStamina++;

        }
        UpdateStaminaImage();
    }
    private IEnumerator RefreshStaminaRoutine(){
        while(true){
            yield return new WaitForSeconds(timeBetweenStaminaRefresh);
            RefreshStamina();
        }

    }
    private void UpdateStaminaImage(){
        for(int i=0;i<maxStamina;i++){
            if(i<=currentStamina-1){
                staminaContainer.GetChild(i).GetComponent<Image>().sprite=fullStaminaImage;
            }else{
                staminaContainer.GetChild(i).GetComponent<Image>().sprite=emptyStaminaImage;
            }
        }
        if(currentStamina<maxStamina){
            StopAllCoroutines();
            StartCoroutine(RefreshStaminaRoutine());
        }
    }

}
