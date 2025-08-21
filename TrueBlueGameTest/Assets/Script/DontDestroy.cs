using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    //static variable that keeps track of its own list that will be shared with all objects with this script
    private static GameObject[] persistentObjects = new GameObject[3]; //increase or decrease for the amount of things that have this script as it'll use this to delete anything over the amount
    public int objectIndex;

    // Start is called before the first frame update
    void Awake()
    {
        if(persistentObjects[objectIndex] == null)
        {
            persistentObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject); //does what it says on the box, wont destroy the parent object between scenes
        }

        else if (persistentObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject);
        }


        
    }

}

//Objects with this script (just in case this causes any issues)
//Inventory
//Player