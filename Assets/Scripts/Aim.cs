using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using System.Drawing;

public class Aim : MonoBehaviour
{
    [SerializeField] private GameObject bow;
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity = 5f;
    [SerializeField] private float aimSensitivity = 1f;

    private ThirdPersonController thirdPersonController;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    //void Update()
    //{
    //    Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    bow.transform.LookAt(target);
    //}

    void Update()
    {
        Vector3 bowDirection = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane));
        bow.transform.LookAt(bowDirection);

        if (Input.GetMouseButton(0))
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
        {
            bow.transform.LookAt(raycastHit.point);
        }
    }
}


