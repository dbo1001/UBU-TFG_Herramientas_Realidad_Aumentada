using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGyro : MonoBehaviour
{
    
    public ParticleSystem particulas;
    // Start is called before the first frame update
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
        Vector3 pos2 = new Vector3();
        pos2.z = 0;
        pos2.y = 0;
        pos2.x = 10;
        //particulas.gravityModifier =10;//pos.y;
        Physics.gravity = Input.gyro.gravity;

        //transform.position = pos;
    }
}
