using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Vector3 rand;

    // Start is called before the first frame update
    void Start()
    {
        // start each puckup object with a random rotation
        rand = new Vector3( Random.Range(-45.0f, 45.0f), Random.Range(-45.0f, 45.0f), Random.Range(-45.0f, 45.0f) );
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rand * Time.deltaTime);
    }
}
