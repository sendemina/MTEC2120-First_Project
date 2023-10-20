using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class Bow : MonoBehaviour
{
    //[SerializeField] private GameObject player; 
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform bowDock;
    [SerializeField] private float arrowForce = 2000f;
    private GameObject newArrow;

    public InputActionReference shootAction;

    private void OnEnable()
    {
        shootAction.action.Enable();
    }

    private void OnDisable()
    {
        shootAction.action.Disable();
    }

    void Start()
    {
        shootAction.action.performed += context =>
        {
            Vector3 bowDirection = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane));
            bowDock.LookAt(bowDirection);
            newArrow = Instantiate(arrowPrefab, bowDock.position, bowDock.rotation, bowDock.transform);
            newArrow.GetComponent<Rigidbody>().isKinematic = true;
        };

        shootAction.action.canceled += context =>
        {
            if (newArrow != null)
            {
                newArrow.GetComponent<Rigidbody>().isKinematic = false;
                newArrow.GetComponent<Rigidbody>().AddForce(bowDock.forward * arrowForce);
            }
        };
    }

    void Update()
    {
        //Vector3 bowDirection = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane));
        //bowDock.LookAt(bowDirection);

        //if (_input.shoot) //left mouse button
        //{
        //    GameObject go = Instantiate(arrowPrefab, bowDock.position, bowDock.rotation);
        //    go.GetComponent<Rigidbody>().AddForce(bowDock.forward * arrowForce);
        //    //_input.shoot = false;
        //}
    }
}
