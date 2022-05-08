using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMeshCarroIA : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent carro;
    
   [SerializeField]
    private Transform posicaoAlvo;
    void Start()
    {
        carro.destination = posicaoAlvo.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
