using UnityEngine;

public class DoorDetector : MonoBehaviour
{
    public GameObject dotUI;

    private DoorInteraction currentDoor;

    void Start()
    {
        if (dotUI != null)
            dotUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            currentDoor = other.GetComponent<DoorInteraction>();

            if (currentDoor != null)
                dotUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            currentDoor = null;
            dotUI.SetActive(false);
        }
    }

    void Update()
    {
        if (currentDoor != null && Input.GetKeyDown(KeyCode.E))
        {
            dotUI.SetActive(false);
            currentDoor.OpenDoor(4f);
        }
    }
}
