using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer_Barrier_Behavior : MonoBehaviour
{
    [SerializeField] private GameObject barrierOn, barrierOff;

    // Start is called before the first frame update
    void Start()
    {
        barrierOn.SetActive(true);
        barrierOff.SetActive(false);
    }

    public void BarrierHit()
    {
        StartCoroutine(BarrierTimer());
    }

    IEnumerator BarrierTimer()
    {
        barrierOn.SetActive(false);
        barrierOff.SetActive(true);
        yield return new WaitForSeconds(8);
        barrierOff.SetActive(false);
        barrierOn.SetActive(true);
    }
}
