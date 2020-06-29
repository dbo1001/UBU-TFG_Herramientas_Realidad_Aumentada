using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Android;



public class ControladorAR : MonoBehaviour
{
    public GameObject regadera;
    public GameObject ventama;
    // Start is called before the first frame update

    public GameObject mergecube;
    public GameObject captura;
    public GameObject captura2;
    public GameObject captura3;

    public GameObject plantaTomate;
    public GameObject plantaCalabaza;
    public GameObject plantaGirasol;

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
        }
        if (controlador.GetCalabaza())
        {
            plantaCalabaza.SetActive(true);
        }
        if (controlador.GetGirasol())
        {
            plantaGirasol.SetActive(true);
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
        if (objeto.active is true)
        {
            objeto.SetActive(false);
        }
        else
        {
            objeto.SetActive(true);
        }
    }


}
