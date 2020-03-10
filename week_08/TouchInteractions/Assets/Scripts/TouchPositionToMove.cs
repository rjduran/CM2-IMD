using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPositionToMove : MonoBehaviour
{
    public Text m_Text;
    public Image m_Img;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the emoji if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                // set position of image in pixels
                // Note: this example works in the screen space only because
                // we are mapping pixels (from touches) to pixels (in Canvas > Image object)
                // and the Main Camera is positioned at 0, 0, -10
                m_Img.rectTransform.position = new Vector3(touch.position.x, touch.position.y, 0.0f); ;
            }            

            // update text display
            m_Text.text = "Touch Position: " + touch.position;

        }        
        
    }
}
