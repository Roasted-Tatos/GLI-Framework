using GameDevHQ.FileBase.Plugins.FPS_Character_Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shooting : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    //[SerializeField] Enemy_Movement AiScript;
    [SerializeField] private int Ammoleft = 15;
    [SerializeField] private AudioClip gunShotSFX,barrierSFX;
    [SerializeField] private Animator _anim;

    private bool onGameMenu;

    private void Start()
    {
        onGameMenu = GameManager.Instance.isGameMenuPaused();
    }

    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            CalculatingAmmo();
            if (Ammoleft > 0 || onGameMenu == true)
            {
                Shoot();
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = gunShotSFX;
                audioSource.Play();
                _anim.SetTrigger("Fire");
            }
        }
    }

    void Shoot()
    {
        Ray rayOrigin = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        if(Physics.Raycast(rayOrigin, out hitInfo))
        {
            Enemy_Movement tmp = hitInfo.collider.GetComponentInChildren<Enemy_Movement>();

            if (hitInfo.collider.CompareTag ("Enemy"))
            {
                Debug.Log("hit " + hitInfo.collider.name);
                tmp.DeathTrigger();
            }
            if(hitInfo.collider.CompareTag("Barrier"))
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource> ();
                audioSource.clip = barrierSFX;
                audioSource.Play();

                Debug.Log("hit " + hitInfo.collider.name);
            }
        }
    }

    void CalculatingAmmo()
    {
        Ammoleft--;
        if(Ammoleft < 0)
        {
            Ammoleft = 0;
        }
    }

    public int TotalAmmo()
    {
        return Ammoleft;
    }
}
