using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilizante : MonoBehaviour
{
    public GameObject fertilizante;
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
    
    void EndAnimationEvent()
    {
        fertilizante.SetActive(false);
    }
}
