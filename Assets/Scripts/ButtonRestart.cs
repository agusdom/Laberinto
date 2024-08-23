using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRestart : MonoBehaviour
{
    public Button restart;
    
    public void ActivarBoton()
    {
        restart.gameObject.SetActive(true);
    }
}
