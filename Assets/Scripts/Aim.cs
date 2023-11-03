using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using System.Drawing;
using UnityEngine.InputSystem;


public class Aim : MonoBehaviour
{
    [SerializeField] private GameObject bow;
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity = 5f;
    [SerializeField] private float aimSensitivity = 1f;

    private ThirdPersonController thirdPersonController;
    public InputActionReference shootAction;


    private void OnEnable()
    {
        shootAction.action.Enable();

    }


    private void OnDisable()
    {
        shootAction.action.Disable();
    }



    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
    }


    void Start()
    {
        shootAction.action.performed += context =>
        {
            aimVirtualCamera.gameObject.SetActive(true);
            //thirdPersonController.SetSensitivity(aimSensitivity);
            Debug.Log("Shoot Action is called. ");

            //Vector3 bowDirection = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane));
            //bow.transform.LookAt(bowDirection);

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
            //{
            //    bow.transform.LookAt(raycastHit.point);
            //}
        };

        shootAction.action.canceled += context =>
        {
            aimVirtualCamera.gameObject.SetActive(false);
            //thirdPersonController.SetSensitivity(normalSensitivity);
        };

    }

    void Update()
    {
        Vector3 bowDirection = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane));
        bow.transform.LookAt(bowDirection);


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
        {
            bow.transform.LookAt(raycastHit.point);
        }
    }


}


