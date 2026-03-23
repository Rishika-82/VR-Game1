using UnityEngine;
using System.Collections;

public class DoorInteraction : MonoBehaviour
{
    private GameObject doorClosed;
    private GameObject doorOpened;

    private bool isOpen = false;

    void Awake()
    {
        // SAFE auto-find (no crash)
        Transform closed = transform.Find("DoorClosed");
        Transform opened = transform.Find("DoorOpened");

        if (closed == null || opened == null)
        {
            Debug.LogError(
                "DoorInteraction: DoorClosed or DoorOpened not found on " + gameObject.name,
                this
            );
            enabled = false;
            return;
        }

        doorClosed = closed.gameObject;
        doorOpened = opened.gameObject;
    }

    void Start()
    {
        doorClosed.SetActive(true);
        doorOpened.SetActive(false);
    }

    public void OpenDoor(float time)
    {
        if (isOpen) return;
        StartCoroutine(OpenRoutine(time));
    }

    private IEnumerator OpenRoutine(float time)
    {
        isOpen = true;

        doorClosed.SetActive(false);
        doorOpened.SetActive(true);

        yield return new WaitForSeconds(time);

        doorOpened.SetActive(false);
        doorClosed.SetActive(true);

        isOpen = false;
    }
}
