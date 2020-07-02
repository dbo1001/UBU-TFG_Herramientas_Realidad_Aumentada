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
    /*
    public GameObject fase1;
    public GameObject fase2;
    public GameObject fase3;
    public GameObject fase4;*/
    public GameObject regadera;
    bool flag = true;
    bool fertilizanteUse = false;
    public GameObject fertilizanteUsed;

    public GameObject ventana;
    public TMPro.TextMeshProUGUI textVentana;
    public Image colorTiempo;
    
    public GameObject planta1;
    public GameObject planta2;
    public GameObject planta3;

    public GameObject planta1CT;
    public GameObject planta2CT;
    public GameObject planta3CT;


    private Plants plants =  new Plants();
    private Controlador controlador = new Controlador();
    GameObject f1;
    GameObject f2;
    GameObject f3;
    GameObject f4;

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

        if (controlador.GetTipoARMergecube())
        {
            if (controlador.GetTomato())
            {
                f1 = planta1.GetComponent<Plants>().GetFase1();
                f2 = planta1.GetComponent<Plants>().GetFase2();
                f3 = planta1.GetComponent<Plants>().GetFase3();
                f4 = planta1.GetComponent<Plants>().GetFase4();
            }
            if (controlador.GetCalabaza())
            {
                f1 = planta2.GetComponent<Plants>().GetFase1();
                f2 = planta2.GetComponent<Plants>().GetFase2();
                f3 = planta2.GetComponent<Plants>().GetFase3();
                f4 = planta2.GetComponent<Plants>().GetFase4();
            }
            if (controlador.GetGirasol())
            {
                f1 = planta3.GetComponent<Plants>().GetFase1();
                f2 = planta3.GetComponent<Plants>().GetFase2();
                f3 = planta3.GetComponent<Plants>().GetFase3();
                f4 = planta3.GetComponent<Plants>().GetFase4();
            }

        }
        else
        {
            if (controlador.GetTomato())
            {
                f1 = planta1CT.GetComponent<Plants>().GetFase1();
                f2 = planta1CT.GetComponent<Plants>().GetFase2();
                f3 = planta1CT.GetComponent<Plants>().GetFase3();
                f4 = planta1CT.GetComponent<Plants>().GetFase4();
            }
            if (controlador.GetCalabaza())
            {
                f1 = planta2CT.GetComponent<Plants>().GetFase1();
                f2 = planta2CT.GetComponent<Plants>().GetFase2();
                f3 = planta2CT.GetComponent<Plants>().GetFase3();
                f4 = planta2CT.GetComponent<Plants>().GetFase4();
            }
            if (controlador.GetGirasol())
            {
                f1 = planta3CT.GetComponent<Plants>().GetFase1();
                f2 = planta3CT.GetComponent<Plants>().GetFase2();
                f3 = planta3CT.GetComponent<Plants>().GetFase3();
                f4 = planta3CT.GetComponent<Plants>().GetFase4();
            }
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
                tiempo = 60;
                if (flag == true)
                {
                    flag = false;
                    tiempo = 60;
                    fertilizanteUse = false;
                    fertilizanteUsed.SetActive(false);
                    f1.SetActive(true);
                    ActualizarProgreso(0);
                }
                else if (f1.active)
                {
                    fertilizanteUse = false;
                    fertilizanteUsed.SetActive(false);
                    tiempo = 60;
                    f1.SetActive(false);
                    f2.SetActive(true);
                    ActualizarProgreso(0);
                    agua = 0;
                }
                else if (f2.active)
                {
                    fertilizanteUsed.SetActive(false);
                    fertilizanteUse = false;
                    tiempo = 60;
                    f2.SetActive(false);
                    f3.SetActive(true);
                    ActualizarProgreso(0);
                    agua = 0;
                }
                else if (f3.active)
                {
                    fertilizanteUse = false;
                    fertilizanteUsed.SetActive(false);
                    tiempo = 60;
                    f3.SetActive(false);
                    f4.SetActive(true);
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
            if (tiempo > 10)
            {
                colorTiempo.color = new Color32(255, 255, 255, 155);
            }
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
                textVentana.text = "<pos=25%><b><size=55>¡¡Has Perdido!!</size></b>\n" +
                    "\n"+
                    "\n"+
                    "Debido a la falta de agua y de abono, la planta no ha podido crecer.";
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
