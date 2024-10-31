using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoinPrefab,healthPrefab,staminaPrefab;

    public void DropItems(){
        int randomNum=Random.Range(1,5);

        if(randomNum==1){
            Instantiate(healthPrefab,transform.position,Quaternion.identity);
        }
        if(randomNum==2){
            Instantiate(staminaPrefab,transform.position,Quaternion.identity);
        }
        if(randomNum==3){
            int randomAmountOfGold=Random.Range(1,10);
            for(int i=0;i<randomAmountOfGold;i++){
                Instantiate(goldCoinPrefab,transform.position,Quaternion.identity);
            }
        }
    }
    public void BossDropItems(){
        int randomNum=Random.Range(1,5);

        if(randomNum==1){
            Instantiate(healthPrefab,transform.position,Quaternion.identity);
            Instantiate(staminaPrefab,transform.position,Quaternion.identity);
            int randomAmountOfGold=Random.Range(1,4);
            for(int i=0;i<randomAmountOfGold;i++){
                Instantiate(goldCoinPrefab,transform.position,Quaternion.identity);
            }
        }
        if(randomNum==2){
            Instantiate(staminaPrefab,transform.position,Quaternion.identity);
            int randomAmountOfGold=Random.Range(1,5);
            for(int i=0;i<randomAmountOfGold;i++){
                Instantiate(goldCoinPrefab,transform.position,Quaternion.identity);
            }
        }
        if(randomNum==3){
            int randomAmountOfGold=Random.Range(1,10);
            for(int i=0;i<randomAmountOfGold;i++){
                Instantiate(goldCoinPrefab,transform.position,Quaternion.identity);
            }
        }
        if(randomNum==4){
            Instantiate(healthPrefab,transform.position,Quaternion.identity);
            Instantiate(staminaPrefab,transform.position,Quaternion.identity);
            int randomAmountOfGold=Random.Range(1,4);
            for(int i=0;i<randomAmountOfGold;i++){
                Instantiate(goldCoinPrefab,transform.position,Quaternion.identity);
            }
        }
        if(randomNum==5){
            Instantiate(healthPrefab,transform.position,Quaternion.identity);
            Instantiate(staminaPrefab,transform.position,Quaternion.identity);
            int randomAmountOfGold=Random.Range(1,4);
            for(int i=0;i<randomAmountOfGold;i++){
                Instantiate(goldCoinPrefab,transform.position,Quaternion.identity);
            }
        }
    }
    

}
