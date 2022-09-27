using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlhaCamera : MonoBehaviour
{

    private GameObject MinhaCamera;
    // Start is called before the first frame update
    void Start()
    {
        MinhaCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(MinhaCamera.transform.position); 
    }
}
