using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPosition : MonoBehaviour
{
    public Text m_Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Touch touch = Input.GetTouch(0);

        m_Text.text = "Touch Position: " + touch.position;
        
    }
}
