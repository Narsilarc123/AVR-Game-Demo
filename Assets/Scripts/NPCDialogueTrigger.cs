using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NPCDialogueTrigger : MonoBehaviour
{
    public string[] dialogueLines;
    private int currentLine = 0;
    private bool playerNear = false;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextLine();
        }
    }

    void ShowNextLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialoguePanel.SetActive(true);
            dialogueText.text = dialogueLines[currentLine];
            currentLine++;
        }
        else
        {
            dialoguePanel.SetActive(false);
            currentLine = 0;
            if (GameManager.Instance.coinsCollected >= 3)
            {
                SceneManager.LoadScene("NextSceneName"); 
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) playerNear = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            dialoguePanel.SetActive(false);
            currentLine = 0;
        }
    }
}