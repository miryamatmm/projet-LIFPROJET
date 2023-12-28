using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource crashThud; 
    public GameObject mainCam;
    public AudioSource honk; 
    public GameObject levelControl;


    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        charModel.GetComponent<Animator>().Play("Tripping");
        levelControl.GetComponent<LevelDistance>().enabled = false;
        crashThud.Play();
        honk.Play();
        mainCam.GetComponent<Animator>().enabled = true;
        levelControl.GetComponent<EndScreen>().enabled = true;
    }
}
