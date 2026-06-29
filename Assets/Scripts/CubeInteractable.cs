using UnityEngine;
using System.Collections;

public class CubeInteractable : InteractableObject
{
    public bool isCorrectCube;

    protected override void OnInteract()
    {
        if (isCorrectCube)
        {
            //correct cube detected , ui and color change
            objectRenderer.material.color = Color.white;

            UIManager.Instance.ShowMessage("Correct");

            AudioManager.Instance.PlaySuccess();

            DisableInteraction();
        }
        else
        {
            //red color flash for some time
            StartCoroutine(FlashRed());

            UIManager.Instance.ShowMessage("Try Again");
        }
    }

    IEnumerator FlashRed()
    {
        //flashred coroutine
        objectRenderer.material.color = Color.red;

        yield return new WaitForSeconds(0.3f);

        objectRenderer.material.color = originalColor;
    }
}