using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMove : MonoBehaviour
{
    // Vitesse de déplacement du carré
    public float speed = 0.5f;

    void Update()
    {
        //transform.Translate(Vector3.left * Time.deltaTime * speed);
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
