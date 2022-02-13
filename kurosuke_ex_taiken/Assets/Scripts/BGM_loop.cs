using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_loop : MonoBehaviour
{

    private bool DontDestroy = true;

    public static BGM_loop Instance
    {
        get; private set;
    }

    // Start is called before the first frame update
    void Start()
    {
        //BGMの複製を防ぐ
        if(Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        if (DontDestroy)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
