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

    }
    //// Update is called once per frame
    //void Update()
    //{

    //}
}
