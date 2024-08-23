using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toten : MonoBehaviour
{
    public Text winner;
    public bool fin;

    private SoundManager soundManager;
    private ButtonRestart botonRestart;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        botonRestart = GameObject.Find("Botoncito").GetComponent<ButtonRestart>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        fin = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            fin = true;
            winner.text = $"Has Ganado!!.Tu tiempo es de {(gameManager.GetTiempoTranscurrido().ToString("F2"))}";
            botonRestart.ActivarBoton();
            gameManager.GetComponent<AudioSource>().Stop();
            soundManager.PlayWin();
        }
    }
}
