using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip winSound, lostSound;

    public void PlayWin()
    {
        PlaySound(winSound);
    }

    public void PlayLost()
    {
        PlaySound(lostSound);
    }


    private void PlaySound(AudioClip nombre)
    {
        GetComponent<AudioSource>().clip = nombre;
        GetComponent<AudioSource>().Play();
    }
}
