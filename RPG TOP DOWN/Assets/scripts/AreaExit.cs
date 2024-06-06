using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToload;
    [SerializeField] private string sceneTransitionName;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>()){
            SceneManager.LoadScene(sceneToload);
            SceneManagement.Instance.SetTransitionName(sceneTransitionName);
        }
    }
}
