using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleScript : MonoBehaviour
{
   public GameObject Player;

    public void UseTele()
    {
        Player.transform.position = new Vector3(-159f, 1.31f, 24.9f);
        Debug.Log("TELEPORT");
    }
}
