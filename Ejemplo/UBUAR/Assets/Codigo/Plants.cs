using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    public GameObject fase1;
    public GameObject fase2;
    public GameObject fase3;
    public GameObject fase4;

    static GameObject f1;
    static GameObject f2;
    static GameObject f3;
    static GameObject f4;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    public GameObject GetFase1()
    {
        f1 = fase1;
        return f1;
    }

    public GameObject GetFase2()
    {
        f2 = fase2;
        return f2;
    }

    public GameObject GetFase3()
    {
        f3 = fase3;
        return f3;
    }

    public GameObject GetFase4()
    {
        f4 = fase4;
        return f4;
    }


}
