using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] float floatHeight = 68.0f;
    [SerializeField] float floatPower = 10.0f;
    Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (transform.position.y < floatHeight)
        {
            rb.AddForce(Vector3.up * floatPower, ForceMode.Force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.1f);
        Debug.Log("Balloon got popped by " + collision.gameObject.name);
    }
}
