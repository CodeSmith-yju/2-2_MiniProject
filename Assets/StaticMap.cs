using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMap : MonoBehaviour
{
    static StaticMap instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
