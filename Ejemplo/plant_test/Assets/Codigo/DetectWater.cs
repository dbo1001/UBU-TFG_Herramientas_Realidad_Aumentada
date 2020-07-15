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

    //Contador de los Target personalizados creados por el usuario.
    int contDefinded = 0;

    public Text textoAgua;
    public Image barraProgreso;

    //Texto de la cuenta atras
    public Text cuentaAtras;
    //Tiempo
    int tiempo = 60;
    bool tFin = false;
    
    public GameObject regadera;
    bool flag = true;
    bool fertilizanteUse = false;
    public GameObject fertilizanteUsed;

    public GameObject ventana;
    public TMPro.TextMeshProUGUI textVentana;
    public GameObject buttonCerrar;
    public GameObject buttonSalir;
    public GameObject buttonReiniciar;
    public Image colorTiempo;

    //Plantas asociadas al Mergecube.
    public GameObject planta1;
    public GameObject planta2;
    public GameObject planta3;

    //Plantas asociadas al Target personalizado de capturaTarget.
    public GameObject planta1CT;
    public GameObject planta2CT;
    public GameObject planta3CT;

    public GameObject tempPlanta1CT;
    public GameObject tempPlanta2CT;
    public GameObject tempPlanta3CT;

    //
    private Plants plants =  new Plants();
    private Controlador controlador = new Controlador();
    GameObject f1;
    GameObject f2;
    GameObject f3;
    GameObject f4;

    bool f1Activa = false;
    bool f2Activa = false;
    bool f3Activa = false;
    bool f4Activa = false;

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
        
        ActualizarProgreso(0);
        ActualizarHud();
    }
    
    //Detecta si se producen colisiones de particulas
    void OnParticleCollision(GameObject other)
    {
        
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
                else if (f1.activeSelf)
                {
                    fertilizanteUse = false;
                    fertilizanteUsed.SetActive(false);
                    tiempo = 60;
                    f1.SetActive(false);
                    f2.SetActive(true);
                    ActualizarProgreso(0);
                    agua = 0;
                }
                else if (f2.activeSelf)
                {
                    fertilizanteUsed.SetActive(false);
                    fertilizanteUse = false;
                    tiempo = 60;
                    f2.SetActive(false);
                    f3.SetActive(true);
                    ActualizarProgreso(0);
                    agua = 0;
                }
                else if (f3.activeSelf)
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
        f1Activa = f1.activeSelf;
        f2Activa = f2.activeSelf;
        f3Activa = f3.activeSelf;
        f4Activa = f4.activeSelf;

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
                buttonCerrar.SetActive(false);
                buttonReiniciar.SetActive(true);
                buttonSalir.SetActive(true);
                //TextAsset txt = (TextAsset)Resources.Load("Textos/textoAyudaModoJuego");
                //TMPro.TextMeshProUGUI text = (TMPro.TextMeshProUGUI)Resources.Load("Textos/textoAyudaModoJuego");
                //string texto = System.IO.File.ReadAllText("Assets/Resources/Textos/textoAyudaModoJuego.txt");
                //string text= Resources.Load("Textos/textoAyudaModoJuego") as string;
                textVentana.text =
                    "<pos=25%><b><size=65>¡¡Has Perdido!!</size></b>\n" +
                    "\n" +
                    "\n" +
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

    //Controla el crecimiento de la barra de progreso.
    public void ActualizarProgreso(float amount)
    {
        agua2 = ((amount * maxPro) / 5000);
        valPro = Mathf.Clamp(agua2, 0, maxPro);
        barraProgreso.transform.localScale = new Vector2(valPro / maxPro, 1);
    }

    //Por cada nuevo target personalizado en el Modo CaptraTarget, actualizar las variables de las fases.
    public void AsociarDefinedTarget()
    {
        if(GameObject.Find("UserDefinedTarget-" + contDefinded.ToString() + "/GameObject1/Planta1"))
        {
            if (controlador.GetTomato())
            {
                tempPlanta1CT = GameObject.Find("UserDefinedTarget-" + contDefinded.ToString() + "/GameObject1/Planta1");
            }

            if (controlador.GetCalabaza())
            {
                tempPlanta1CT = GameObject.Find("UserDefinedTarget-" + contDefinded.ToString() + "/GameObject1/Planta2");
            }

            if (controlador.GetGirasol())
            {
                tempPlanta1CT = GameObject.Find("UserDefinedTarget-" + contDefinded.ToString() + "/GameObject1/Planta3");
            }

            //si f1 es distinto de null y esta activo
            if (controlador.GetTipoARcapturar())
            {
                f1 = tempPlanta1CT.GetComponent<Plants>().GetFase1();
                f2 = tempPlanta1CT.GetComponent<Plants>().GetFase2();
                f3 = tempPlanta1CT.GetComponent<Plants>().GetFase3();
                f4 = tempPlanta1CT.GetComponent<Plants>().GetFase4();

                if (f1Activa)
                    f1.SetActive(true);
                if (f2Activa)
                    f2.SetActive(true);
                if (f3Activa)
                    f3.SetActive(true);
                if (f4Activa)
                    f4.SetActive(true);

            }

        }
        
        
    }

    public void DesactivarPanelYNcapturatarget()
    {
        GameObject obj;
        if (!GameObject.Find("UserDefinedTarget-" + contDefinded.ToString() + "/GameObject1/Planta1"))
        {
            obj =GameObject.Find("Canvas/CampturarTarget/Panel");
            obj.SetActive(false);
        }
           

    }
    public void AumentarContDefinedTarget()
    {
        contDefinded++;
    }
    
    public bool GetGameOver()
    {
        return tFin;
    }

    public void Reiniciar()
    {
        //reset bool GAmeOVer
        tFin = false;
        //reset time
        colorTiempo.color = new Color32(255, 255, 255, 155);
        tiempo = 60;
        cuentaAtras.text = "" + tiempo;
        //Cierro ventana GameOver
        ventana.SetActive(false);

        agua = 0;        
    
        //reincicio fases de las plantas
        flag=true;
        fertilizanteUse = false;
        f1.SetActive(false);
        f2.SetActive(false);
        f3.SetActive(false);
        f4.SetActive(false);
        
        ActualizarProgreso(0);
        ActualizarHud();
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (GameObject.Find("UserDefinedTarget-"+contDefinded.ToString()).activeSelf)
    //    {
    //        AsociarDefinedTarget();
    //        contDefinded++;
    //    }
    //}
}
