using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;

    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    [Header("Dialogue")]
    public Dialogue dialogue;

    [Header("Optional Reward")]
    public InventoryItem rewardItem;

    private bool hasTriggered = false;

    public void TriggerDialogue()
    {
        if (hasTriggered) return;

        hasTriggered = true;

        DialogueManager.Instance.StartDialogue(dialogue, this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TriggerDialogue();
        }
    }

    public void GiveReward()
    {
        if (rewardItem != null)
        {
            InventoryManager.Instance.AddItem(rewardItem);
        }
    }
}