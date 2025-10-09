using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Test : MonoBehaviour

{
     public float interactDistance = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("portal"))
                {
                    hit.collider.transform.GetComponent<TeleScript>().UseTele();
                }

                if (hit.collider.CompareTag("Objective"))
                {
                    hit.collider.transform.GetComponent<keyScript>().UseKey();
                }
            }
        }  
    }
    
}
