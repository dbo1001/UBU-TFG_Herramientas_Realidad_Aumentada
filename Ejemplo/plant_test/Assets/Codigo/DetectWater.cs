using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectWater : MonoBehaviour
{
    public ParticleSystem pSystem;
    public List<ParticleCollisionEvent> collisionEvents;
    public static int agua = 0;
    public Text textoAgua;
    public GameObject fase1;
    public GameObject fase2;
    public GameObject fase3;
    public GameObject fase4;
    public GameObject regadera;
    bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        if (pSystem == null)
        {
            Debug.LogError("No funciona jajaja", this);
            return;
        }
        ActualizarHud();
    }

    void OnParticleCollision(GameObject other)
    {
        //int contact = pSystem.GetSafeCollisionEventSize();
        //if (contact > collisionEvents.Count)
        //    collisionEvents = new ParticleCollisionEvent[contact];
        if (pSystem == null)
        {
            Debug.LogError("No funciona jajaja", this);
            return;
        }
        agua = agua + pSystem.GetCollisionEvents(other, collisionEvents);
        ActualizarHud();
    }
    void ActualizarHud()
    {
        //agua = agua + agua;
        textoAgua.text = "Agua: " + agua;
        if (agua >= 5000)
        {
            agua = 0;
            if (flag == true)
            {
                flag = false;
                fase1.SetActive(true);
            }
            else if (fase1.active)
            {
                fase1.SetActive(false);
                fase2.SetActive(true);
                agua = 0;
            }
            else if (fase2.active)
            {
                fase2.SetActive(false);
                fase3.SetActive(true);
                agua = 0;
            }
            else if (fase3.active)
            {
                fase3.SetActive(false);
                fase4.SetActive(true);
                regadera.SetActive(false);
                agua = 0;
            }
            
        }
    }
    //// Update is called once per frame
    //void Update()
    //{

    //}
}
