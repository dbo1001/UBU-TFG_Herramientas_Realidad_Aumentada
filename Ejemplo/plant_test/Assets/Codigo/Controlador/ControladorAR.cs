using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Android;



public class ControladorAR : MonoBehaviour
{
    public GameObject regadera;
    public GameObject ventama;
    public TMPro.TextMeshProUGUI textVentana;
    public GameObject buttonCerrar;
    public GameObject buttonSalir;
    public GameObject buttonReiniciar;
    // Start is called before the first frame update

    public GameObject mergecube;
    public GameObject captura;
    public GameObject captura2;
    public GameObject captura3;

    public GameObject plantaTomate;
    public GameObject plantaCalabaza;
    public GameObject plantaGirasol;

    public GameObject plantaTomate2;
    public GameObject plantaCalabaza2;
    public GameObject plantaGirasol2;

    public GameObject botonPruebas;

    private Controlador controlador = new Controlador();

    //Se activa al ejecutar el script, activa la configuración inicial de elementos activos visibles.
    public void Start()
    {

#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
#endif

        regadera.SetActive(false);
        ventama.SetActive(false);
        textVentana.text = "<pos=25%><b><size=65>Ayuda</size></b>\n" +
                    "\n" +
                    "<pos=25%><b><size=45>Modo MergeCube</size></b>\n" +
                    "-Mantenga enfocado el Mergecube en un ambiente con buena iluminación para que pueda ser detectado.\n" +
                    "-En la parte inferior derecha, se encuentra la barra de herramientas, en la que encontraremos.\n"+
                    "---<b>Icono regadera</b>: activa la regadera.\n" +
                    "---<b>Icono Fertilizante</b>: activa el fertilizante.\n" +
                    "---<b>Fijar Posición</b>: activa el Device traking, permitiendo que el modelo 3D sea persistente incluso sin verse el Mergecube o el target.\n" +
                    "---<b>Captura de Pantalla</b>: permite realizar capturas de pantalla.\n" +
                    "<pos=25%><b><size=45>Modo Captura Target</size></b>\n" +
                    "La barra de colores indica la calidad del objetivo como target.\n" +
                    "-<b>Unicamente puede haber un solo target al mismo tiempo</b>.\n" ;
        buttonCerrar.SetActive(true);
        buttonReiniciar.SetActive(false);
        buttonSalir.SetActive(false);

        //modo ar
        if (controlador.GetTipoARcapturar())
        {
            mergecube.SetActive(false);

            captura.SetActive(true);
            captura2.SetActive(true);
            captura3.SetActive(true);
        }
        if (controlador.GetTipoARMergecube())
        {
            mergecube.SetActive(true);
            captura.SetActive(false);
            captura2.SetActive(false);
            captura3.SetActive(false);
        }

        //planta activada
        if (controlador.GetTomato())
        {
            plantaTomate.SetActive(true);
            plantaTomate2.SetActive(true);
        }
        if (controlador.GetCalabaza())
        {
            plantaCalabaza.SetActive(true);
            plantaCalabaza2.SetActive(true);
        }
        if (controlador.GetGirasol())
        {
            plantaGirasol.SetActive(true);
            plantaGirasol2.SetActive(true);
        }
        //Pone a cero el progreso al entrar al nivel.
        DetectWater.agua=0;

        if (SystemInfo.deviceType == DeviceType.Handheld)
            botonPruebas.SetActive(false);
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ActivarDesactivarHerramienta(GameObject objeto)
    {
        if (objeto.activeSelf is true)
        {
            objeto.SetActive(false);
        }
        else
        {
            objeto.SetActive(true);
        }
    }

    public void AbrirHyperEnlace(string link)
    {
        Application.OpenURL(link);
    }

    
    //void Update()
    //{
    //    GameObject obj;
    //    if (ImageTargetBuilder.FrameQuality.FRAME_QUALITY_LOW || ImageTargetBuilder.FrameQuality.FRAME_QUALITY_NONE)
    //    {
    //        obj = GameObject.Find("Canvas/CampturarTarget/Panel");
    //        obj.SetActive(false);
    //    }

    //}

}
