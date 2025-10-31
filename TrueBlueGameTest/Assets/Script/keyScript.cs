using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour, IInteractable
{
    public GameObject doorCollider;

    public void Interact(Player player)
    {
        doorCollider.SetActive(false);
        Debug.Log("OBJECTIVE ACHIEVED");
    }
}
