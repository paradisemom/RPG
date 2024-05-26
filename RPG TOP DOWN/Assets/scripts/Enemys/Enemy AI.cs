using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiAI : MonoBehaviour
{
    [SerializeField]private float roamChangeDirFloat=2f; 
    private enum State{
        Roaming
    }
    private State state;
    private EnemyPathFinding enemyPathFinding;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        enemyPathFinding=GetComponent<EnemyPathFinding>();
        state=State.Roaming;
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        StartCoroutine(RoamRoutine());
    }

    private IEnumerator RoamRoutine()
    {
        while(state==State.Roaming){
            Vector2 roamPosition=GetRoamPosition();
            enemyPathFinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(roamChangeDirFloat);
        }
    }

    private Vector2 GetRoamPosition()
    {
        return new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized;
    }
}
