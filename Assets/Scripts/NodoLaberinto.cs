using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EstadoNodo{
    Disponible,
    Actual,
    Ocupado
}
public class NodoLaberinto : MonoBehaviour
{
    [SerializeField] GameObject[] paredes;
    [SerializeField] MeshRenderer suelo;

    public void BorrarPared(int paredARemover)
    {
        paredes[paredARemover].gameObject.SetActive(false);
    }
    public void EstablecerEstado(EstadoNodo estado)
    {
        switch (estado)
        {
            case EstadoNodo.Disponible:
                suelo.material.color = Color.white;
                break;
            case EstadoNodo.Actual:
                suelo.material.color = Color.yellow;
                break;
            case EstadoNodo.Ocupado:
                suelo.material.color = Color.blue;
                break;

        }
    }

}
