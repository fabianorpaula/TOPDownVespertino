using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Heroi : MonoBehaviour
{
    private NavMeshAgent Agente;
    private Vector3 Destino;

    // Start is called before the first frame update
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        Destino = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }

    void Mover()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousepoint = Input.mousePosition;
            Ray castpoint = Camera.main.ScreenPointToRay(mousepoint);
            RaycastHit hit;
            if(Physics.Raycast(castpoint, out hit, Mathf.Infinity))
            {
                Destino = hit.point;
            }
        }

        Agente.SetDestination(Destino);
    }
}
