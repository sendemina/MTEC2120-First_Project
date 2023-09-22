using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    [SerializeField] GameObject splash;


    [SerializeField] Collider leftFoot;
    [SerializeField] Collider rightFoot;


    private void OnTriggerEnter(Collider other)
    {

        if(other.GetComponent<Collider>() == leftFoot || other.GetComponent<Collider>() == rightFoot)
        {

            Instantiate(splash, other.gameObject.transform.position, Quaternion.identity);
            Debug.Log("splashed");
        }

    }
}
