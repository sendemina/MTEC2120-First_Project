using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private GameObject bow;

    void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bow.transform.LookAt(target * -1);
    }

    //void Method2()
    //{
    //    RaycastHit rayHit;
    //    if(Physics.Raycast())
    //}
}
