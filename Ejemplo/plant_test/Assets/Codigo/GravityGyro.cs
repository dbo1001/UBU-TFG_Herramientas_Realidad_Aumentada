using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityGyro : MonoBehaviour
{
    public ParticleSystem particulas;
    //public Text ejes;
    // Start is called before the first frame update
    /*public int x;
    public int y;
    public int z;*/
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3();
        /*Vector3 pos2 = new Vector3();
        pos2.z = x;
        pos2.y = y;
        pos2.x = z;*/
        /*
         * //Este testo es para comprobar las cordenadas dados por el giroscopio
        ejes.text = "El eje X =" + Input.gyro.gravity.x + " " +
            "El eje Y =" + Input.gyro.gravity.y + " " +
            "El eje Z " + Input.gyro.gravity.z;
        pos = Input.gyro.gravity;*/
        //Cuando la camara mira hacia abajo,invierte el eje Z.
        if (Input.gyro.gravity.z < 0)
            pos.z = pos.z * (-1);
        Physics.gravity = pos;
        
    }
}
