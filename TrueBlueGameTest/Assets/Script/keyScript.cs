using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    public GameObject doorCollider;

    public void UseKey()
    {
        doorCollider.SetActive(false);
        Debug.Log("OBJECTIVE ACHIEVED");
    }
}
