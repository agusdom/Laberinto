using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoPlayer : MonoBehaviour
{
    [SerializeField]private Transform objetivo;
    private Vector3 nuevaPosicion;


    private void Start()
    {
        nuevaPosicion = transform.position - objetivo.transform.position;
        
    }

    private void Update()
    {
        Seguimiento();
    }
    void Seguimiento()
    {
        
        if (objetivo != null)
        {
            objetivo = GameObject.FindWithTag("Player").GetComponent<Transform>();
            transform.position = new Vector3(objetivo.transform.position.x + nuevaPosicion.x, objetivo.transform.position.y + nuevaPosicion.y, objetivo.transform.position.z);
        }
    }
}
