using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //This manages the inventory system in the game! Right now the button for it is set to 'e' in the unity project settings
    public GameObject InventoryMenu;
    private bool menuActivated; //checks if on or off

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated) //activates and deactivates menu when hitting the inventory button
        {
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("Inventory") && !menuActivated) //I spent 20 minutes confused one why this wasnt working and I had forgotten to put the '!' i actually want to feed a baby highly corrosive liquids
        {
           // Time.timeScale = 0; //might cause issues with animations if you want to add them I say as im commenting to myself
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public void AddItem(string itemName, int quantity, GameObject itemObject) // I DONT KNOW WHAT THE FUCK IM DOING
    {
        Debug.Log("itemName = " + itemName + "quantity = " + quantity + "itemObject = " + itemObject); //THIS MIGH BE A PROBLEM THERE IS NO SPRITE PICKUP ITS JUST THE ITEM OBJECT IDFK HOW THIS IS GOING TO WORK KMS KMS KMS KMS KMS KMS
    }
}
