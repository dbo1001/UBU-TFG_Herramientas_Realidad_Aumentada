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

    public Text cuentaAtras;
    int tiempo = 60;
    bool tFin = false;

    public GameObject fase1;
    public GameObject fase2;
    public GameObject fase3;
    public GameObject fase4;
    public GameObject regadera;
    bool flag = true;
    bool fertilizanteUse = false;

    public GameObject ventana;
    public TMPro.TextMeshProUGUI textVentana;
    public Image colorTiempo;


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
        //StartCoroutine(CuentaAtras());
    }

    //void Update()
    //{
    //    //StartCoroutine(CuentaAtras());
       
    //}


    //Detecta si se producen colisiones de particulas
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

    //Actualiza el hud de la interfaz segun el progreso de las fases.
    void ActualizarHud()
    {
        //agua = agua + agua;
        textoAgua.text = "Agua: " + agua;
        

        
        if (tFin == false)
        {
            ActualizarProgreso(agua);
            if (agua >= 5000 & fertilizanteUse == true)
            {
                agua = 0;
                if (flag == true)
                {
                    flag = false;
                    tiempo = 60;
                    fertilizanteUse = false;
                    fase1.SetActive(true);
                    ActualizarProgreso(0);
                }
                else if (fase1.active)
                {
                    fertilizanteUse = false;
                    tiempo = 60;
                    fase1.SetActive(false);
                    fase2.SetActive(true);
                    ActualizarProgreso(0);
                    agua = 0;
                }
                else if (fase2.active)
                {
                    fertilizanteUse = false;
                    tiempo = 60;
                    fase2.SetActive(false);
                    fase3.SetActive(true);
                    ActualizarProgreso(0);
                    agua = 0;
                }
                else if (fase3.active)
                {
                    fertilizanteUse = false;
                    tiempo = 60;
                    fase3.SetActive(false);
                    fase4.SetActive(true);
                    regadera.SetActive(false);
                
                    agua = 0;
                }

            }
            
            
        }
        
    }

    IEnumerator CuentaAtras()
    {
        if (tiempo > 0)
        {
            tiempo =tiempo-1;
            //if (tiempo<0)
            //{
            //    cuentaAtras.text = ""+0;
            //    tFin = true;
            //    yield break;

            //}
            cuentaAtras.text =""+tiempo;
            if (5 < tiempo & tiempo < 10)
            {
                colorTiempo.color = new Color32(255, 244, 40, 155);
            }
            if (5 > tiempo)
            {
                colorTiempo.color = new Color32(255, 100, 0, 155);
            }


            yield return new WaitForSeconds(1);
            StartCoroutine(CuentaAtras());
        }
        else
        {
            tFin = true;
            if (tFin == true)
            {
                ventana.SetActive(true);
                textVentana.text = " Debido a la falta de agua, la planta ha muerto";
                colorTiempo.color = new Color32(231,62,62,155);
                
            }
        }

    }

    public void InitTiempo()
    {
        if(pSystem.IsAlive())
            StartCoroutine(CuentaAtras());
    }

    public void FertilizanteUsado()
    {
         fertilizanteUse = true;
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
