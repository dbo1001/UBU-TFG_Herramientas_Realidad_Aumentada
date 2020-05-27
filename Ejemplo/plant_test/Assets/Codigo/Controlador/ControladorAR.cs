using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ControladorAR : MonoBehaviour
{
    public GameObject regadera;
    public GameObject ventama;
    // Start is called before the first frame update

    public GameObject mergecube;
    public GameObject captura;
    public GameObject captura2;
    public GameObject captura3;

    private Controlador controlador = new Controlador();

    public void Start()
    {
        regadera.SetActive(false);
        ventama.SetActive(false);
        
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
