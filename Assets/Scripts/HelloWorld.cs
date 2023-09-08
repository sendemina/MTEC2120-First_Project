using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private GameObject m_otherObject; //m - member (private object)

    Renderer rend;

    public GameObject otherObject //public property
    {
        get { return m_otherObject; }
        set { m_otherObject = value;  }
    }

    void Start()
    {
        Debug.Log("Hello World");
        rend = GetComponent<Renderer>();
        if (!rend) Debug.LogError("There is no renderer!");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed!");
            //transform.position = new Vector3(100, 100, 100);
            rend.material.color = RandomColor();
        }
    }

    public Color RandomColor()
    {
        return new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
    }
}
