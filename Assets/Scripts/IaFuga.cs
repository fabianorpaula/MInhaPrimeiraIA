using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IaFuga : MonoBehaviour
{
    private NavMeshAgent Agente;
    public List<GameObject> Locais;
    private GameObject Destino;
    public bool estadoFoge = false;
    public GameObject Lobo;

    void Start()
    {
        Agente  = GetComponent<NavMeshAgent>();
        Teletransporte();


    }
    void Update()
    {
        if(estadoFoge == false)
        {
            EstadoAtoa();
        }
        if(estadoFoge == true)
        {
            EstadoFugindo();
        }

    }

    void EstadoFugindo()
    {
        Agente.SetDestination(Destino.transform.position);
        //Calcula Distancia
        float proximidade = Vector3.Distance(transform.position,
            Destino.transform.position);
        if (proximidade < 5)
        {
            Sorteio();
        }
        //Calcula Medo
        float medo = Vector3.Distance(transform.position,
            Lobo.transform.position);
        if (proximidade > 40)
        {
            estadoFoge = false;
        }

    }

    void EstadoAtoa()
    {
        //nada
    }



    void Sorteio()
    {
        int posicao = Random.Range(0, Locais.Count);
        Destino = Locais[posicao];
    }

    void Teletransporte()
    {
        int posicao = Random.Range(0, Locais.Count);
        Destino = Locais[posicao];
        transform.position = Destino.transform.position;
    }

    private void OnTriggerEnter(Collider ouvindo)
    {
        if (ouvindo.gameObject.tag == "LoboMau")
        {
            Lobo = ouvindo.gameObject;
            estadoFoge = true;
        }
    }


}
