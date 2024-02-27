using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;

public class IaInteligente : MonoBehaviour
{
    public GameObject Alvo;
    public NavMeshAgent Agente;
    public List<GameObject> CasaList;
    public int CasaAlvo;
    public bool estadoCaca = false;

    void Start()
    {
        CasaAlvo = SortearCasa();
        Agente= GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Movimento();
    }

    int SortearCasa()
    {
        int sorteio = Random.Range(0, CasaList.Count);

        return sorteio;
    }

    void Movimento()
    {
        //Estado de Procura
        if (estadoCaca == false)
        {
            //Estou procurando a Chapeuzinho
            Agente.SetDestination(CasaList[CasaAlvo].transform.position);
            float distancia = Vector3.Distance(transform.position,
                CasaList[CasaAlvo].transform.position);

            if (distancia < 6)
            {
                CasaAlvo = SortearCasa();
            }
        }
        //Estado de Caça
        if(estadoCaca == true) {
            Agente.SetDestination(Alvo.transform.position);
        }

    }

    private void OnTriggerEnter(Collider farejar)
    {
       if(farejar.gameObject.tag == "Chapeuzinho")
        {
            estadoCaca= true;
        } 
    }

}
