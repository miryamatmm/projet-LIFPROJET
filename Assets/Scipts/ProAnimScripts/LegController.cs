using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderLeg : MonoBehaviour
{
    public float speed = 3f;
    public float footSpacing = 1.5f; 
    public float stepDistance = 1f;
    public float stepHeight = 1.5f;

    [SerializeField] SpiderLeg otherFoot = default;

    public bool moving = false;
    private float lerp;
    private Vector3 oldPosition;
    private Vector3 newPosition;
    private Vector3 currentPosition;

    public LayerMask terrainLayer; 
    public Transform body; 

    private void Start()
    {
        //footSpacing = transform.localPosition.z;
        currentPosition = newPosition = oldPosition = transform.position;
        lerp = 1;
    }

    void Update()
    {
        transform.position = currentPosition; 

        Ray ray = new Ray(body.position +transform.right * footSpacing , Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit info, 30, terrainLayer.value) && !otherFoot.IsMoving())
        {
            float distance = Vector3.Distance(newPosition, info.point);
            
            if (distance > stepDistance)
            {
                lerp = 0;
                newPosition = info.point;
                moving = true;
            }
        }

        if (moving)
        {
            currentPosition = Vector3.MoveTowards(currentPosition, newPosition, lerp);
            lerp += Time.deltaTime * speed;
            //StartCoroutine(WaitAndContinue(2f));
        }
    }

        IEnumerator WaitAndContinue(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        // Logique à exécuter après l'attente
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(newPosition, 0.05f);
    }

    public bool IsMoving()
    {
        return lerp<1;
    }
}
