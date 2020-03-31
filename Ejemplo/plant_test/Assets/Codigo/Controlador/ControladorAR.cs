using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControladorAR : MonoBehaviour
{
    // Start is called before the first frame update
    public void VolverMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
