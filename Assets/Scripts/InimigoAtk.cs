using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class InimigoAtk : MonoBehaviour
{
    private GameObject Heroi;
    private NavMeshAgent Agente;
    public int vida = 10;
    public int vidaMax = 10;
    public Slider BarraHP;
   
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        Heroi = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Agente.SetDestination(Heroi.transform.position);
    }
    private void OnTriggerEnter(Collider colisao)
    {
        if(colisao.gameObject.tag == "AreaAtkHeroi")
        {
            vida--;
            BarraHP.value = vida;
            if(vida <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
