using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    [SerializeField] private GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomBall();
    }

    void SpawnRandomBall()
    {
        Instantiate(objeto,new Vector3(Random.Range(-10,9),0,Random.Range(-10, 9)),Quaternion.identity);
    }
}
