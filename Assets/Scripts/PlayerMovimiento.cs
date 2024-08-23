using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimiento : MonoBehaviour
{
    private float velocidad;
    private Toten toten;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 5f;
        toten = GameObject.Find("TotenSalida").GetComponent<Toten>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPlayer();
    }

    void MovimientoPlayer()
    {
        if (!toten.fin)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * velocidad * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * velocidad * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            }
        }
    }
}
