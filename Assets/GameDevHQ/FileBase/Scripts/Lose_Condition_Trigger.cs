using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose_Condition_Trigger : MonoBehaviour
{
    [SerializeField] private int EscapistCounter = 0;

    // Update is called once per frame
    void Update()
    {
        if (EscapistCounter == 5)
        {
            GameManager.Instance.GameOver();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy")) 
        {
            EscapistCounter++;
            Debug.Log("one escaped");
        }
    }
}
