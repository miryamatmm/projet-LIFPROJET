using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Transform body; // Le transform du corps
    public Transform legs; // Le transform des jambes
    public float moveSpeed = 5f; // Vitesse de déplacement des jambes
    public float maxDistance = 2f; // Distance maximale entre les jambes et la cible avant que les jambes ne bougent

    private ConfigurableJoint legJoint;

    void Start()
    {
        // Assurez-vous que les composants Rigidbody sont attachés aux objets (body, legs).

        // Créez un ConfigurableJoint pour connecter les jambes au corps.
        legJoint = legs.gameObject.AddComponent<ConfigurableJoint>();
        ConfigureJoint();
    }

    void Update()
    {
        // Obtenez l'entrée pour le mouvement du corps
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // Calculez le mouvement du corps
        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
        body.Translate(movement * moveSpeed * Time.deltaTime);

        // Mettez à jour la position de la cible (target) par rapport aux jambes
        UpdateTargetPosition();
    }

    void UpdateTargetPosition()
    {
        // Obtenez la distance entre les jambes et la cible
        float distanceToTarget = Vector3.Distance(legs.position, transform.position);

        // Si la distance est supérieure à la distance maximale, bougez les jambes
        if (distanceToTarget > maxDistance)
        {
            MoveLegs();
        }
    }

    void MoveLegs()
    {
        // Implémentez ici la logique pour faire bouger les jambes
        // Par exemple, animez les jambes, changez leur position, etc.
        // Vous pouvez également ajuster la logique pour répondre à vos besoins spécifiques.
        Debug.Log("Les jambes bougent !");
    }

    void ConfigureJoint()
    {
        // Configurez le joint pour limiter le mouvement
        legJoint.connectedBody = body.GetComponent<Rigidbody>();
        legJoint.anchor = Vector3.zero;
        legJoint.axis = Vector3.up;
        legJoint.autoConfigureConnectedAnchor = false;
        legJoint.connectedAnchor = new Vector3(0, 1, 0); // Ajustez cela en fonction de la position relative des jambes par rapport au corps.
        legJoint.xMotion = ConfigurableJointMotion.Locked;
        legJoint.yMotion = ConfigurableJointMotion.Limited;
        legJoint.zMotion = ConfigurableJointMotion.Locked;
        SoftJointLimit limit = new SoftJointLimit();
        limit.limit = maxDistance;
        legJoint.linearLimit = limit;
    }
}
