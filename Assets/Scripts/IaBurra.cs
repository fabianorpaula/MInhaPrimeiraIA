using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaBurra : MonoBehaviour
{
    public GameObject Alvo;
    void Update()
    {

        transform.position = Vector3.MoveTowards(
            transform.position, Alvo.transform.position, 0.01f);

    }
}
