using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mist : MonoBehaviour
{
    [SerializeField] GameObject sphere;
    private void OnTriggerEnter(Collider other)
    {
        GameObject go = Instantiate(sphere);
        go.GetComponent<MeshRenderer>().material.color = new Color
            (Random.Range(0.4f, 0.9f), Random.Range(0.4f, 0.6f), Random.Range(0.0f, 0.3f));
    }
}
