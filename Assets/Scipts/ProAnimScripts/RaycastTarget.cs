using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTarget : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, Vector3.down * 10, Color.red);

        if(Physics.Raycast(transform.position, Vector3.down, out hit, 10) && hit.transform.name != "Plane"){
            //Debug.Log("Le raycast a touché un objet");

            // Obtenir la normale de la surface de l'obstacle
            Vector3 surfaceNormal = hit.normal;

            // Calculer la nouvelle position de l'objet en fonction de la normale
            Vector3 newPosition = hit.point + surfaceNormal * 0.2f;

            // Mettre à jour la position de l'objet pour qu'il suive la forme de l'obstacle
            transform.position = newPosition;

            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, surfaceNormal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
        }
    }
}
