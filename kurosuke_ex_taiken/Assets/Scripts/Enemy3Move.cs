using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Move : MonoBehaviour
{
    private int move;
    private int e;

    // Start is called before the first frame update
    void Start()
    {
        move = 0;
        e = 1;
    }

    // Update is called once per frame
    void Update()
    {
        move += e;

        if (move > 0)
        {
            transform.position -= transform.right * 0.1f;
            if (move == 40)
            {
                move = 0;
                e = -1;
            }
        }
        if (move < 0)
        {
            transform.position += transform.right * 0.1f;
            if (move == -40)
            {
                move = 0;
                e = 1;
            }
        }
    }
}
