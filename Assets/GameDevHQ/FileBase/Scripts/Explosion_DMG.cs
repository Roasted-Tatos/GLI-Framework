using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_DMG : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy_Movement tmp = other.GetComponent<Enemy_Movement>();
            if(tmp != null)
            {
                tmp.DeathTrigger();
            }
        }
    }
}
