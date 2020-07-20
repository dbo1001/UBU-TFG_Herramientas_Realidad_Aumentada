using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityGyro : MonoBehaviour
{
    
    public ParticleSystem particulas;
    public Text ejes;
    // Start is called before the first frame update
    void Start()
    {
        /*
        if (SystemInfo.supportsGyroscope)
        {}*/
        //Detecta si es un mobil, tablet ... o un sistema distinto.
        if(SystemInfo.deviceType==DeviceType.Handheld && SystemInfo.supportsGyroscope)
            Input.gyro.enabled = true;
        else
            Input.gyro.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3();
        Vector3 gDefecto = new Vector3();
        gDefecto.z = 0;
        gDefecto.y = -9;
        gDefecto.x = 0;
        /**/
        //Este testo es para comprobar las cordenadas dados por el giroscopio
        ejes.text ="El eje X =" + Input.gyro.gravity.x + " " +
            "El eje Y =" + Input.gyro.gravity.y + " " +
            "El eje Z " + Input.gyro.gravity.z;

        if (Input.gyro.enabled)
        {
            pos = Input.gyro.gravity;
            //Cuando la camara mira hacia abajo,invierte el eje Z.
            /*if (Input.gyro.gravity.z < 0)//<
            {}*/
            pos.z = pos.z * (-1);
            
        }
        else
        {
            pos = gDefecto;
        }
            
        Physics.gravity = pos;

        
    }
}
