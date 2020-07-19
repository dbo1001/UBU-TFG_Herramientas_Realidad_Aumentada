using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Controlador : MonoBehaviour
{
    public GameObject menu1;
    public GameObject menu1_1;
    public GameObject menu1_1_1;

    public GameObject menu1_2;
    public GameObject atras;
    public GameObject menu1_3;
    public GameObject menu1_4;

    public GameObject menu2;
    public GameObject menu2_1;
    public GameObject menu2_1_1;

    public GameObject menu2_2;
    public GameObject menu2_3;
    public GameObject menu2_4;
    public GameObject atras2;

    
    public GameObject multiTarget;
    public GameObject camaraAR;

    public Toggle tipoMergeCube;
    public Toggle tipoCapturaTarget;
    public Toggle tipoMergeCube_AR;
    public Toggle tipoCapturaTarget_AR;
    static bool tipoARMerge=true;
    static bool tipoARCaptura=false;

    static bool tipoMultiTarget = false;

    static bool tomatoLive = false;
    static bool calabazaLive = false;
    static bool giraSolLive = false;

    public TMPro.TextMeshProUGUI textAyuda;
    public TMPro.TextMeshProUGUI textInfo;

    // Start is called before the first frame update

    public void CambiarEscena(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    //Controla el botón Atras del menú.
    public void Atras()
    {
        if (menu1.activeSelf)
        {
            Application.Quit();
        }
        if (menu1_1.activeSelf)
        {
            //normal
            menu1_1.SetActive(false);
            menu1.SetActive(true);
            atras.SetActive(false);

            //ar
            menu2_1.SetActive(false);
            menu2.SetActive(true);
            atras2.SetActive(false);
        }

        if (menu1_1_1.activeSelf)
        {
            //normal
            menu1_1_1.SetActive(false);
            menu1_1.SetActive(true);

            //ar
            menu2_1_1.SetActive(false);
            menu2_1.SetActive(true);

        }

        if (menu1_2.activeSelf || menu1_3.activeSelf || menu1_4.activeSelf)
        {
            //normal
            menu1_2.SetActive(false);
            menu1_3.SetActive(false);
            menu1_4.SetActive(false);
            menu1.SetActive(true);
            atras.SetActive(false);

            //ar
            menu2_2.SetActive(false);
            menu2_3.SetActive(false);
            menu2_4.SetActive(false);
            menu2.SetActive(true);
            atras2.SetActive(false);

        }
    }

    

    //Actualiza el tipo de Target ha usar.
    public void TipoDeAR()
    {
        if (!multiTarget.activeSelf)
        {
            if (tipoMergeCube.isOn)
            {
                tipoARCaptura = false;
                tipoARMerge = true;
                PlayerPrefs.SetInt("tipoMarcador",0);

            }
            else if (tipoCapturaTarget.isOn)
            {
                tipoARCaptura = true;
                tipoARMerge = false;
                PlayerPrefs.SetInt("tipoMarcador", 1);
            }
        }
        else
        {
            if (tipoMergeCube_AR.isOn)
            {
                tipoARCaptura = false;
                tipoARMerge = true;
                PlayerPrefs.SetInt("tipoMarcador", 0);
            }
            else if (tipoCapturaTarget_AR.isOn)
            {
                tipoARCaptura = true;
                tipoARMerge = false;
                PlayerPrefs.SetInt("tipoMarcador", 1);
            }
        }
    
    }
    //Sincroniza los Toggle entre el menu normal y el de AR.
    public void SyncTipoAR()
    {

        if (!multiTarget.activeSelf)
        {
            tipoMergeCube.isOn = tipoMergeCube_AR.isOn;
            tipoCapturaTarget.isOn = tipoCapturaTarget_AR.isOn;
        }
        else
        {
            tipoMergeCube_AR.isOn= tipoMergeCube.isOn;
            tipoCapturaTarget_AR.isOn= tipoCapturaTarget.isOn;
        }
    }

    
    public  bool GetTipoARMergecube()
    {
        return tipoARMerge;
    }

    public  bool GetTipoARcapturar()
    {
        return tipoARCaptura;
    }

    public bool GetIsMultiTarget()
    {
        return tipoMultiTarget;
    }

    public void SetIsMultiTarget(bool multi)
    {
        tipoMultiTarget = multi;
    }

    public void ActivarTomate()
    {
        tomatoLive = true;
        //desactivar el resto de plantas
        calabazaLive = false;
        giraSolLive = false;

    }

    public void ActivarCalabaza()
    {
        calabazaLive = true;
        //desactivar el resto de plantas
        tomatoLive = false;
        giraSolLive = false;
    }

    public void ActivarGiraSol()
    {
        giraSolLive = true;
        //desactivar el resto de plantas
        calabazaLive = false;
        tomatoLive = false;

    }

    public bool GetTomato()
    {
        return tomatoLive;
    }

    public bool GetCalabaza()
    {
        return calabazaLive;
    }

    public bool GetGirasol()
    {
        return giraSolLive;
    }

    public void Start()
    {
        //normal
        menu1.SetActive(true);
        menu1_1.SetActive(false);
        menu1_1_1.SetActive(false);
        menu1_2.SetActive(false);
        menu1_3.SetActive(false);
        menu1_4.SetActive(false);
        atras.SetActive(false);
        //ar
        menu2.SetActive(true);
        menu2_1.SetActive(false);
        menu2_1_1.SetActive(false);
        menu2_2.SetActive(false);
        menu2_3.SetActive(false);
        menu2_4.SetActive(false);
        //menu2_4.SetActive(false);

        camaraAR.SetActive(false);
        multiTarget.SetActive(false);
        int tipoMarcador=PlayerPrefs.GetInt("tipoMarcador",0);
        if (tipoMarcador == 0)
        {
            tipoCapturaTarget.isOn=false;
            tipoMergeCube.isOn = true;

            tipoCapturaTarget_AR.isOn = false;
            tipoMergeCube_AR.isOn = true;

        }
        else
        {
            tipoCapturaTarget.isOn = true;
            tipoMergeCube.isOn = false;

            tipoCapturaTarget_AR.isOn = true;
            tipoMergeCube_AR.isOn = false;

        }
        TipoDeAR();
        
        textAyuda.text= System.IO.File.ReadAllText("Assets/Resources/Textos/textoAyudaMenu.txt"); 
        textInfo.text= System.IO.File.ReadAllText("Assets/Resources/Textos/textoInfoUTF16BE.txt");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Atras();
        }
    }

}
