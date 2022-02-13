using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    private int move; //動きのパターンを制御

    // Start is called before the first frame update
    void Start()
    {
        move = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(move == 0)
        {
            transform.position -= transform.right * 0.1f;
            if (transform.position.x < -5f)
            {
                move = 1;
            }
        }
        if (move == 1)
        {
            transform.position += transform.right * 0.1f;
            if (transform.position.x > 3f)
            {
                move = 2;
            }
        }
        if(move == 2)
        {
            transform.position += transform.forward * 0.1f;
            if(transform.position.z > 12f)
            {
                move = 3;
            }
        }
        if(move == 3)
        {
            transform.position -= transform.right * 0.1f;
            transform.position -= transform.forward * 0.1f;
            if (transform.position.z < 3f)
            {
                move = 0;
            }
        }

    }
}
