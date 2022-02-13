using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    private Text Title;
    private float r, g, b;

    // Start is called before the first frame update
    void Start()
    {
        Title = this.GetComponent<Text>();
        r = 0.0f;
        g = 0.0f;
        b = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Title.color = new Color(r, g, b, 1.0f);
        r += 0.01f;
        g += 0.05f;
        b += 0.03f;
        if(r > 1.0f)
        {
            r -= 1.0f;
        }
        if (g > 1.0f)
        {
            g -= 1.0f;
        }
        if (b > 1.0f)
        {
            b -= 1.0f;
        }
    }
}
