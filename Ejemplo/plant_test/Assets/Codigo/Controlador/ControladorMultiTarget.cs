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

    string nombreModelo;

    Vector3 scale;
    Vector3 posicion;
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

        scale = new Vector3(0.8f, 0.8f, 0.8f);
        posicion = new Vector3(0.0f, 0.8f, 0.0f);
        //GameObject.Find("UserDefinedTarget-" + contDefinded.ToString() + "/GameObject1/Planta1");
    }
    
    //Carga la scena del menú
    public void VolverMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void AumetarEscala()
    {
        GameObject.Find(nombreModelo).transform.localScale += scale;
        GameObject.Find(nombreModelo).transform.position += posicion;
    }

    public void DecrementarEscala()
    {
        GameObject.Find(nombreModelo).transform.localScale -= scale;
        GameObject.Find(nombreModelo).transform.position -= posicion;
    }

    //Comprueba que objeto se selecciona/toca en la pantalla mediante raycast.
    void Update()
    {
        if(Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began ||Input.GetMouseButtonDown(0))
        {
            Ray ray;
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            }
            else
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);          

            }

            RaycastHit Hit;
            
            if (Physics.Raycast(ray, out Hit)){
                var model = Hit.collider.GetComponentInParent<Transform>();
                if (model != null)
                {
                    nombreModelo =model.name;
                    
                }
                
            }

        }

    }
}
