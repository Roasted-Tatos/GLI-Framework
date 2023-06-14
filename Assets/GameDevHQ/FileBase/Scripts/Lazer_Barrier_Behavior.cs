using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer_Barrier_Behavior : MonoBehaviour
{
    [SerializeField] private GameObject barrierOn, barrierOff;
    [SerializeField] private int respawnTimer;
    [SerializeField] private AudioSource breakSFX;
    [SerializeField] private AudioClip breakAudioClip;
    [SerializeField] private BoxCollider barrierCollider;

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
        breakSFX.PlayOneShot(breakAudioClip);
        barrierOff.SetActive(true);
        barrierCollider.enabled = false;
        yield return new WaitForSeconds(respawnTimer);
        barrierOff.SetActive(false);
        barrierOn.SetActive(true);
        barrierCollider.enabled = true;
    }
}
