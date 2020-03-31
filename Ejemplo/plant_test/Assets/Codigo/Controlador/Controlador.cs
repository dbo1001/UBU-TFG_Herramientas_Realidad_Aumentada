using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Controlador : MonoBehaviour
{
    public GameObject menu1;
    public GameObject menu1_1;
    public GameObject menu1_1_1;
    public GameObject atras;



    // Start is called before the first frame update

    public void CambiarEscena(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Atras()
    {
        if (!menu1.active)
        {
            if (!menu1_1.active)
            {
                menu1_1_1.SetActive(false);
                menu1_1.SetActive(true);
            }
            else{
                menu1_1.SetActive(false);
                menu1.SetActive(true);
                atras.SetActive(false);
            }
        }
    }

    public void Start()
    {
        menu1.SetActive(true);
        menu1_1.SetActive(false);
        menu1_1_1.SetActive(false);
        atras.SetActive(false);

    }
}
