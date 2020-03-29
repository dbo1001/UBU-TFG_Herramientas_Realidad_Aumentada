using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectWater : MonoBehaviour
{
    public ParticleSystem pSystem;
    public List<ParticleCollisionEvent> collisionEvents;
    public static int agua = 0;
    public static float agua2;
    float valPro;
    float maxPro = 100;

    public Text textoAgua;
    public Image barraProgreso;

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
        ActualizarProgreso(0);
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
        
        ActualizarProgreso(agua);
        if (agua >= 5000)
        {
            agua = 0;
            if (flag == true)
            {
                flag = false;
                fase1.SetActive(true);
                ActualizarProgreso(0);
            }
            else if (fase1.active)
            {
                fase1.SetActive(false);
                fase2.SetActive(true);
                ActualizarProgreso(0);
                agua = 0;
            }
            else if (fase2.active)
            {
                fase2.SetActive(false);
                fase3.SetActive(true);
                ActualizarProgreso(0);
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
    public void ActualizarProgreso(float amount)
    {
        agua2 = ((amount * maxPro) / 5000);
        valPro = Mathf.Clamp(agua2, 0, maxPro);
        barraProgreso.transform.localScale = new Vector2(valPro / maxPro, 1);
    }
    //// Update is called once per frame
    //void Update()
    //{

    //}
}
