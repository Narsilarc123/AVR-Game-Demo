using UnityEngine;
using TMPro; // 需要 TextMeshPro

public class PlayerTalk : MonoBehaviour
{
    public Canvas dialogueCanvas;          // 对话框 UI
    public TextMeshProUGUI dialogueText;   // 对话内容
    public string[] dialogueLines;         // 对话数组
    private bool playerInRange = false;
    private int dialogueIndex = 0;

    void Start()
    {
        dialogueCanvas.enabled = false; // 初始关闭对话框
    }

    void Update()
    {
        // 玩家在范围内并按下 E 键
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShowDialogue();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 确认是玩家
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueCanvas.enabled = false; // 离开自动关闭
            dialogueIndex = 0; // 重置对话
        }
    }

    void ShowDialogue()
    {
        dialogueCanvas.enabled = true;

        if (dialogueIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            dialogueCanvas.enabled = false;
            dialogueIndex = 0;
        }
    }
}
