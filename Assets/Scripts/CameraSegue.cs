using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    private GameObject Heroi;
    public float minhaAltura;
    // Start is called before the first frame update
    void Start()
    {
        Heroi = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Heroi.transform.position.x, minhaAltura, Heroi.transform.position.z-5);
    }
}
