using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 34.0f;
    private Rigidbody rb;
    private Vector3 acc;

    public Text info;

    private int count;
    public Text countText;
    public Text winText;

    private int numToWin = 4;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    private void Update()
    {
        Vector3 accel = GetAccelerometerValue();

        acc = new Vector3(accel.x, 0, accel.y);

        //clamp acceleration vector to the unit sphere
        if (acc.sqrMagnitude > 1)
        {
            acc.Normalize();
        }

        // Display accelerometer values
        info.text = "Accelerometer = " + accel + "\n" + "acc = " + acc;
        
    }


    void FixedUpdate()
    {                
        rb.AddForce(acc * speed);
    }

    // Function to read accelerometer values with more precision
    // Ref: https://docs.unity3d.com/Manual/MobileInput.html
    Vector3 GetAccelerometerValue()
    {
        Vector3 acc = Vector3.zero;
        float period = 0.0f;

        foreach (AccelerationEvent evnt in Input.accelerationEvents)
        {
            acc += evnt.acceleration * evnt.deltaTime;
            period += evnt.deltaTime;
        }
        if (period > 0)
        {
            acc *= 1.0f / period;
        }
        return acc;
    }

    private void OnTriggerEnter(Collider other)
    {
        // check if the GameObject is tagged "Pickup"
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false); //  disable GameObject touched

            count = count + 1; // increment count value
            //Debug.Log(count);
            SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= numToWin)
        {
            winText.text = "You Win!!";
        }
    }
}
