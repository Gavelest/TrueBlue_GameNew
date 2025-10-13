using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Test : MonoBehaviour

{
    public float interactDistance = 5f;

    void Update()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green); //shows raycast for debugging reasons, if seeing green lines is annoying feel free to comment this out including the code above lmao

        if (Input.GetKeyDown(KeyCode.E)) //KeyCode.E 
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {

                Debug.Log($"Raycast hit object: {hit.transform.name} with tag: {hit.transform.tag}", hit.transform.gameObject); //debug shows what object is being seen by the raycast

                if (hit.collider.CompareTag("portal"))
                {
                   hit.collider.transform.GetComponent<TeleScript>().UseTele();
                    Debug.Log("Portal");
                }

                if (hit.collider.CompareTag("Objective"))
                {
                    hit.collider.transform.GetComponent<keyScript>().UseKey();
                }

                if (hit.collider.CompareTag("Item")) //when making new items please make sure their colliders are in the floor due to the raycast being below the feet of the character
                {
                    hit.collider.transform.GetComponent<Item>().Interact();
                }


                if (hit.collider.CompareTag("KeyPad"))
                {
                    hit.collider.GetComponent<Keypad>().KeypadScreen();
                    Debug.Log("code");
                }


            }
        }  
    }
    
}
