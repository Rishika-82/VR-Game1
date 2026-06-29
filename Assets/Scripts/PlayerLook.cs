using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    //raycast minimum distance
    [SerializeField] private float interactionDistance = 10f;

    private void Update()
    {
        //using raycast for cube detection
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {   
            InteractableObject interactable =
                hit.collider.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}