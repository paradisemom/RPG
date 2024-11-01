using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economymanager : SingleTon<Economymanager>
{
    private TMP_Text goldText;
    private int currentGold;

    const string COIN_AMOUNT_TEXT="GoldCoinCountText";
    public void UpdateCurrentCoin(){
        currentGold+=1;
        if(goldText==null){
            goldText=GameObject.Find(COIN_AMOUNT_TEXT).GetComponent<TMP_Text>();
        }
        goldText.text=currentGold.ToString("D3");
    }
}
