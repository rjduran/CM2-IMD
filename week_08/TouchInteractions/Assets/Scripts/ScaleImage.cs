using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleImage : MonoBehaviour
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
        var fingerCount = 0;

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
                m_Text.text =
                    "fingerCount: " + fingerCount + "\n" +
                    "touch (" + touch.fingerId + "): \n" +
                    "  touch.position: " + touch.position + "\n" +
                    "  touch.pressure: " + touch.pressure + "\n" +
                    "  touch.radius: " + touch.radius + "\n";

                // scale width and height of image from 200 to 500
                // touch pressure range: 0 to 6.66

                // returns a value from 0 to 1.0 based on touch.pressure
                float pressureN = Mathf.InverseLerp(0.00f, 6.66f, touch.pressure);
                // use the normalized touch value to rescale
                float size = Mathf.Lerp(200.0f, 500.0f, pressureN);

                // set size of image
                m_Img.rectTransform.sizeDelta = new Vector2(size, size);
            }

        }

    }
}

/*
REFS:
https://docs.unity3d.com/ScriptReference/Touch.html
https://docs.unity3d.com/ScriptReference/Mathf.html
https://forum.unity.com/threads/re-map-a-number-from-one-range-to-another.119437/
https://forum.unity.com/threads/how-to-change-the-size-of-a-ui-image-from-code-trying-to-make-a-simple-healthbar-from-this.265024/
*/
