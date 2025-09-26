using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleScript : MonoBehaviour
{
   public GameObject Player;

    public void UseTele()
    {
        Player.transform.position = new Vector3(12f, 0f, 13f);
        Debug.Log("TELEPORT");
    }
}
