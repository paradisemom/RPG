using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoinPrefab;

    public void DrapItems(){
        Instantiate(goldCoinPrefab,transform.position,Quaternion.identity);
    }

}
