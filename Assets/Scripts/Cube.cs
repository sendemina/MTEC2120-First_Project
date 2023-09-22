using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] float arrowForce = 2000;
    BoxCollider cubeCollider;

    private void Start()
    {
        cubeCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
        //GameObject go = Instantiate(arrow);
        //go.GetComponent<Rigidbody>().AddForce(new Vector3(0,arrowForce,0));
    }
}
