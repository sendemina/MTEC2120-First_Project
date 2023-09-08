using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform bowDock;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //left mouse button
        {
            GameObject go = Instantiate(arrowPrefab, bowDock.position, bowDock.rotation);
            go.GetComponent<Rigidbody>().AddForce(bowDock.forward * 1000f);
        }
    }
}
