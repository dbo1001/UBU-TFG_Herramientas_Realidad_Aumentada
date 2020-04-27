using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilizante : MonoBehaviour
{
    public GameObject fertilizante;
    public GameObject boton;

    Vector3 pos;
    Quaternion rot;
    //public AnimationClip animation;
    //public Animator animator;
    // Start is called before the first frame update
    //void Start()
    //{
    //    fertilizante.anim
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
    void InitPositionEvent()
    {
        pos= fertilizante.transform.position;
        rot=fertilizante.transform.rotation;
    }
    //Evento animacion que desactiva el modelo
    void EndAnimationEvent()
    {
        fertilizante.SetActive(false);
        boton.SetActive(false);
        //fertilizante.transform.SetPositionAndRotation(pos,rot);
    }
}
