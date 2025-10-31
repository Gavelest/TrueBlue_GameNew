using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TeleScript : MonoBehaviour, IInteractable
{
   public Vector3 TeleportDestination;
   
    public Action OnPlayerTeleported;
    public Action OnPlayerFirstTeleported;

    private bool hasTeleported;

    public void Interact(Player player)
    {
        player.transform.position = TeleportDestination;
        Debug.Log("TELEPORT");
        
        OnPlayerTeleported?.Invoke();
        if(!hasTeleported)
        {
            hasTeleported = true;
            OnPlayerFirstTeleported?.Invoke();
        }
    }
}
