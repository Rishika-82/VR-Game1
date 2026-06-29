using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    protected Renderer objectRenderer;
    protected Color originalColor;
    protected bool canInteract = true;

    protected virtual void Awake()
    {
        //random color
        objectRenderer = GetComponent<Renderer>();
        originalColor = Random.ColorHSV();

        objectRenderer.material.color = originalColor;
    }

    public void Interact()
    {
        if (!canInteract)
            return;

        OnInteract();
    }

    protected abstract void OnInteract();

    protected void DisableInteraction()
    {
        canInteract = false;
    }
}