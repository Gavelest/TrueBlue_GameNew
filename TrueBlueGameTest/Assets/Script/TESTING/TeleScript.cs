using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleScript : MonoBehaviour
{
   public GameObject Player;
   public Vector3 TeleportDestination;
   
    public void UseTele()
    {
        Player.transform.position = TeleportDestination;
        Debug.Log("TELEPORT");
    }
}
