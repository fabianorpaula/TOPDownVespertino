using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Heroi : MonoBehaviour
{
    private NavMeshAgent Agente;
    private Vector3 Destino;
    public GameObject Inimigo;
    public bool atacando = false;
    public GameObject AreaDeAtk;
    public GameObject Poder1;
    public bool poder1usado = false;
    public float poder1resp;
    public Slider BarraHp;
    public Slider BarraMana;
    public int vida = 100;
    public int vidaMax = 100;
    public int mana = 100;
    public int manaMax = 100;


    public LayerMask LM;
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
        Atacar();
        Poderes();
    }

    void Atacar()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousepoint = Input.mousePosition;
            Ray castpoint = Camera.main.ScreenPointToRay(mousepoint);
            RaycastHit hit;
            if (Physics.Raycast(castpoint, out hit, Mathf.Infinity))
            {
                if(hit.collider.gameObject.tag == "Inimigo")
                {
                    Inimigo = hit.collider.gameObject;
                }
            }
        }
        if(Inimigo != null)
        {
            Destino = Inimigo.transform.position;
            Agente.SetDestination(Destino);
            if(Vector3.Distance(transform.position, Destino) < 3)
            {
                GetComponent<Animator>().SetBool("Atacando", true);
                transform.LookAt(Destino);
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("Atacando", false);
        }
        
    }

    void Mover()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Inimigo = null;
            Vector3 mousepoint = Input.mousePosition;
            Ray castpoint = Camera.main.ScreenPointToRay(mousepoint);
            RaycastHit hit;
            if(Physics.Raycast(castpoint, out hit, Mathf.Infinity))
            {
                Destino = hit.point;
            }
        }

        Agente.SetDestination(Destino);
        if (Vector3.Distance(transform.position, Destino) < 1)
        {
            GetComponent<Animator>().SetBool("Andando", false);

        }
        else
        {
            GetComponent<Animator>().SetBool("Andando", true);
        }
    }


    public void AtivarAtk()
    {
        AreaDeAtk.SetActive(true);
    }

    public void DesativarAtk()
    {
        AreaDeAtk.SetActive(false);
    }

    public void Poderes()
    {
        if(poder1usado == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Poder1.SetActive(true);
                poder1usado = true;
                mana = mana - 10;
                BarraMana.value = mana;
            }
        }
        else {
            poder1resp += Time.deltaTime;
            if(poder1resp >= 4)
            {
                Poder1.SetActive(false);
            }if(poder1resp >= 10)
            {
                poder1resp = 0;
                poder1usado = false;
                
            }
        }

        
    }


    private void OnTriggerEnter(Collider colisao)
    {
        if (colisao.gameObject.tag == "AreaAtkInimigo")
        {
            vida--;
            BarraHp.value = vida;
            if (vida <= 0)
            {
                //Destroy(this.gameObject);
            }
        }
    }

}
