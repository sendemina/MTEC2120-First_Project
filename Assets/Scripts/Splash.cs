using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        //this.transform.localScale /= 2;
    }
}
