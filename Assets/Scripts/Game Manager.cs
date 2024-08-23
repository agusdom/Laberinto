using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;


public class GameManager : MonoBehaviour
{
    public GameObject player,finish;
    public Transform startPosition;
    public Text loser;
    public delegate void TiempoTranscurrido(float tiempo);
    public static event TiempoTranscurrido eventoTiempoTranscurrido;

    private SoundManager soundManager;
    private ButtonRestart botonRestart;
    private Toten totens;
    private float tiempoTranscurrido;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        totens = GameObject.Find("TotenSalida").GetComponent<Toten>();
        botonRestart = GameObject.Find("Botoncito").GetComponent<ButtonRestart>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        eventoTiempoTranscurrido?.Invoke(tiempoTranscurrido);
    }

    // Update is called once per frame
    void Update()
    {
        if (totens.fin) return;
        IniciarTiempo();
        HasPerdido();

    }

    void StartGame()
    {
        Instantiate(player, startPosition.position, Quaternion.identity);
        finish.SetActive(true);
    }

    private float IniciarTiempo()
    {
        tiempoTranscurrido += Time.deltaTime;
        eventoTiempoTranscurrido?.Invoke(tiempoTranscurrido);
        return tiempoTranscurrido;
    }

    public float GetTiempoTranscurrido()
    {
        return tiempoTranscurrido;
    }


    public void HasPerdido()
    {
        if (tiempoTranscurrido >= 40f)
        {
            totens.fin = true;
            loser.text = "Se te termino el tiempo!!!!";
            botonRestart.ActivarBoton();
            GetComponent<AudioSource>().Stop();
            soundManager.PlayLost();
        }
    }

}
