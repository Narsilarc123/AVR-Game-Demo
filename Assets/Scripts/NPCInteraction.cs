using UnityEngine;
using UnityEngine.UI; 

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueUI;
    private bool isNearNPC = false;

    void Update()
    {
        if (isNearNPC && Input.GetKeyDown(KeyCode.E))
        {
            dialogueUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            isNearNPC = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            isNearNPC = false;
            dialogueUI.SetActive(false);
        }
    }
}
