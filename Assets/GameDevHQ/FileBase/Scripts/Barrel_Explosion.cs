using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Explosion : MonoBehaviour
{
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private bool isDestroyed;
    [SerializeField] private MeshRenderer barrelRenderer;
    [SerializeField] private BoxCollider colliderTrigger;
    [SerializeField] private GameObject hitBox;
    [SerializeField] private AudioSource explosionSFX;
    // Start is called before the first frame update
    void Start()
    {
        explosionVFX.SetActive(false);
        isDestroyed = false;
        hitBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDestroyed == true)
        {
            barrelRenderer.enabled = false;
            colliderTrigger.enabled = false;
        }
    }

    public void ExplosionTrigger()
    {
        explosionVFX.SetActive(true);
        StartCoroutine(DestructionCD());
    }

    IEnumerator DestructionCD()
    {
        yield return new WaitForSeconds(1f);
        isDestroyed = true;
        hitBox.SetActive(true);
        explosionSFX.Play();
        yield return new WaitForSeconds(1f);
        hitBox.SetActive(false);

    }
}
