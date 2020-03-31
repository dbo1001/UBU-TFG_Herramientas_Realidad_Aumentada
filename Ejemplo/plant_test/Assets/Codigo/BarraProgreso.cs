using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarraProgreso : MonoBehaviour
{
    //public Image fondo;
    public Image progreso;

    float valPro;
    float maxPro = 100f;
    // Start is called before the first frame update
    void Start()
    {
        valPro = 0;
    }
    
    public void ActualizarProgreso(float amount)
    {
        valPro = Mathf.Clamp(valPro+amount,0f,maxPro);
        progreso.transform.localScale = new Vector2(valPro/maxPro,1);
    }
}
