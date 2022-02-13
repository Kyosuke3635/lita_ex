using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public Text time_text;
    private float time;
    public bool End;

    // Start is called before the first frame update
    void Start()
    {
        time = 90f;
        //time_text.color = new Color(0f, 0f, 0f, 1f);
        End = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (End == false)
        {
            time -= Time.deltaTime;

            time_text.text = ("Time : ") + time.ToString("00.0");
            if (time < 20f)
            {
                time_text.color = new Color(1f, 0f, 0f, 1f);
            }
            if (time < 0f)
            {
                End = true;
            }
        }
    }
}
