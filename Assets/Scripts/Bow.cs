using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    //[SerializeField] private GameObject player; 
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform bowDock;
    [SerializeField] private float arrowForce = 2000f;

    void Start()
    {
        
    }

    void Update()
    {
        //Vector3 bowDirection = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane));
        //bowDock.LookAt(bowDirection);
        if (Input.GetMouseButtonUp(0)) //left mouse button
        {
            GameObject go = Instantiate(arrowPrefab, bowDock.position, bowDock.rotation);
            go.GetComponent<Rigidbody>().AddForce(bowDock.forward * arrowForce);
        }
    }
}
