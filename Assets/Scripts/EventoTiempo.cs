using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventoTiempo : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.eventoTiempoTranscurrido += TiempoTranscurrido;
    }

    private void OnDisable()
    {
        GameManager.eventoTiempoTranscurrido -= TiempoTranscurrido;
    }

    public void TiempoTranscurrido(float tiempo)
    {
        GetComponent<Text>().text = $"Tiempo:{tiempo:F2}s";
    }
}
