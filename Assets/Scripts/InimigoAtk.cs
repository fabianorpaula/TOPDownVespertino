using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class InimigoAtk : MonoBehaviour
{
    private GameObject Heroi;
    private NavMeshAgent Agente;
    public int vida = 10;
    public int vidaMax = 10;
    public GameObject BarraHP;
   
    // Start is called before the first frame update
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        Heroi = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Agente.SetDestination(Heroi.transform.position);
        

    }

    private void OnTriggerEnter(Collider colisao)
    {
        if(colisao.gameObject.tag == "AreaAtkHeroi")
        {
            vida--;
            if(vida <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
