using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shooting : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Enemy_Movement AiScript;

    private void Start()
    {
        
    }

    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
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
        }
    }
}
