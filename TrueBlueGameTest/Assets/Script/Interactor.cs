using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable {
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    //this should be on the player camera

    public Transform InteractorSource; //stores transform for which the range will be casted on it
    public float InteractRange; //stores range

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact")) {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}

// Used for item pick up but can used for other systems!

// When trying to make something interactable, add it to their object script
// i.e. From the tutorial I was watching they used a Number generator
// ===== EXAMPLE =====
// public class NumberGenerator : MonoBehaviour, IInteractable {
//      public void Interact() {
//          Debug.Log(Random.Range(0, 100));
//      }
// }
// ===================
// added to the class script!
// this makes it so the class requires the interact function to work
// Thus, this can be used for item pick ups, dialogue interactions and more!