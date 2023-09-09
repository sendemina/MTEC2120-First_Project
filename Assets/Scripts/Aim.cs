using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private GameObject bow;

    //void Update()
    //{
    //    Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    bow.transform.LookAt(target);
    //}

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
        {
            bow.transform.LookAt(raycastHit.point);
        }
    }
}
