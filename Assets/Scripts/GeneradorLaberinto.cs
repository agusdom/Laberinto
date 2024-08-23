using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorLaberinto : MonoBehaviour
{
    [SerializeField] NodoLaberinto nodoPrefab;
    [SerializeField] Vector2Int tama�oLaberinto;
    int tama�oNodo;
    private void Start()
    {
        GenerarElLaberinto(tama�oLaberinto);
    }

    void GenerarElLaberinto(Vector2Int tama�o)
    {
        List<NodoLaberinto> nodos = new List<NodoLaberinto>();

        //Crear Nodo
        for (int x = 0; x < tama�o.x; x++)
        {
            for (int y = 0; y < tama�o.y; y++) {
                Vector3 nodoPosicion = new Vector3(x - (tama�o.x / 2f), 0, y - (tama�o.y / 2));
                NodoLaberinto nuevoNodo = Instantiate(nodoPrefab,nodoPosicion,Quaternion.identity,transform);
                nodos.Add(nuevoNodo);

     
            }
        }

        List<NodoLaberinto> actualTrayecto = new List<NodoLaberinto>();
        List<NodoLaberinto> nodosOcupados = new List<NodoLaberinto>();

        //Elegir Nodo Inicio
        actualTrayecto.Add(nodos[Random.Range(0, nodos.Count)]);
        actualTrayecto[0].EstablecerEstado(EstadoNodo.Actual);

        while(nodosOcupados.Count < nodos.Count)
        {
            // Verificar Nodo siguiente al actual nodo
            List<int> posibleNodoSiguiente = new List<int>();
            List<int> posibleDireccion = new List<int>();

            int actualNodoIndice = nodos.IndexOf(actualTrayecto[actualTrayecto.Count - 1]);
            int actualNodoX = actualNodoIndice / tama�o.y;
            int actualNodoY = actualNodoIndice % tama�o.y;

            if (actualNodoX < tama�o.x -1)
            {
                //Verifico nodo a la derecha del actual nodo
                if (!nodosOcupados.Contains(nodos[actualNodoIndice +  tama�o.y]) && !actualTrayecto.Contains(nodos[actualNodoIndice + tama�o.y]))
                {
                    posibleDireccion.Add(1);
                    posibleNodoSiguiente.Add(actualNodoIndice + tama�o.y);
                }
                if (actualNodoX > 0)
                {
                    //Verifico nodo a la izquierda del actual nodo
                    if (!nodosOcupados.Contains(nodos[actualNodoIndice - tama�o.y]) && !actualTrayecto.Contains(nodos[actualNodoIndice - tama�o.y]))
                    {
                        posibleDireccion.Add(2);
                        posibleNodoSiguiente.Add(actualNodoIndice - tama�o.y);
                    }
                }
            }

            if (actualNodoY < tama�o.y - 1)
            {
                //Verifico nodo superior del actual nodo
                if (!nodosOcupados.Contains(nodos[actualNodoIndice + 1]) && !actualTrayecto.Contains(nodos[actualNodoIndice + 1]))
                {
                    posibleDireccion.Add(3);
                    posibleNodoSiguiente.Add(actualNodoIndice + 1);
                }
            }
            if (actualNodoY > 0)
            {
                //Verifico nodo inferior del actual nodo
                if (!nodosOcupados.Contains(nodos[actualNodoIndice - 1]) && !actualTrayecto.Contains(nodos[actualNodoIndice - 1]))
                {
                    posibleDireccion.Add(4);
                    posibleNodoSiguiente.Add(actualNodoIndice - 1);
                }
            }

            //Verificar proximo nodo
            if (posibleDireccion.Count > 0)
            {
                int elegirDireccion = Random.Range(0,posibleDireccion.Count);
                NodoLaberinto elegirNodo = nodos[posibleNodoSiguiente[elegirDireccion]];

                switch (posibleDireccion[elegirDireccion])
                {
                    case 1:
                        elegirNodo.BorrarPared(1);
                        actualTrayecto[actualTrayecto.Count - 1].BorrarPared(0);
                        break;
                    case 2:
                        elegirNodo.BorrarPared(0);
                        actualTrayecto[actualTrayecto.Count - 1].BorrarPared(1);
                        break;
                    case 3:
                        elegirNodo.BorrarPared(3);
                        actualTrayecto[actualTrayecto.Count - 1].BorrarPared(2);
                        break;
                    case 4:
                        elegirNodo.BorrarPared(2);
                        actualTrayecto[actualTrayecto.Count - 1].BorrarPared(3);
                        break;
                }

                actualTrayecto.Add(elegirNodo);
               
            }
            else
            {
                nodosOcupados.Add(actualTrayecto[actualTrayecto.Count - 1]);
                actualTrayecto[actualTrayecto.Count - 1].EstablecerEstado(EstadoNodo.Ocupado);
                actualTrayecto.RemoveAt(actualTrayecto.Count - 1);
            }

        }
    }
}
