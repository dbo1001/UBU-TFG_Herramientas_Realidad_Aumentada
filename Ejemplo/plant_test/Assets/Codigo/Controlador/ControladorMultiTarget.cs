using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class ControladorMultiTarget : MonoBehaviour
{
    
    public GameObject ImaDTarget;
    public GameObject UDTBuilder;
    public GameObject captura3;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
#endif
        ImaDTarget.SetActive(true);
        UDTBuilder.SetActive(true);
        captura3.SetActive(true);


    }
    
    //Carga la scena del menú
    public void VolverMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
