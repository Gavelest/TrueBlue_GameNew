using UnityEngine;
using System;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;

    public Action onPlayerSpeaking;
    public Action onPlayerFirstSpokenToo;

    private bool hasTalked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {
            player.Interactable = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {
            if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;
            }
        }
    }

    public void Interact(Player player)
    {
        player.DialogueUI.ShowDialogue(dialogueObject);

        onPlayerSpeaking?.Invoke();
        if (!hasTalked)
        {
            hasTalked = true;
            onPlayerFirstSpokenToo?.Invoke();
        }
    }
}
