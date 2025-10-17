using System.Collections;
using System.Collections.Generic;
using TrueBlueGameTest.Assets.Script.Items;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //This manages the inventory system in the game! Right now the button for it is set to 'e' in the unity project settings
    public GameObject InventoryMenu;
    private bool menuActivated; //checks if on or off
    public ItemSlot[] itemSlot;
    public ItemData[] heldItem;

    [SerializeField]
    private Image descriptionImage;

    private void Awake()
    {
        foreach (ItemSlot slot in itemSlot)
        {
            slot.itemDescriptionImage = descriptionImage;
        }

    }

    // Update is called once per frame
    void Update()
    {
        descriptionImage.enabled = descriptionImage.sprite != null;

        if (Input.GetButtonDown("Inventory") && menuActivated) //activates and deactivates menu when hitting the inventory button
        {
            Time.timeScale = 1; //starts time
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("Inventory") && !menuActivated) //I spent 20 minutes confused one why this wasnt working and I had forgotten to put the '!' i actually want to feed a baby highly corrosive liquids
        {
            Time.timeScale = 0; // stops time - might cause issues with animations if you want to add them I say as im commenting to myself
            InventoryMenu.SetActive(true);
            menuActivated = true;
            //this messes with the intro message if the inventory is opened too early
        }
    }

    public bool UseItem(string itemName)
    {
        Debug.Log(2);
        for (int i = 0; i < heldItem.Length; i++) //checks array list for matching scriptable object
        {
            if(heldItem[i].itemName == itemName)
            {
               bool usable = heldItem[i].UseItem();
                return usable;
            }
        }
        return false;
    }

    public int AddItem(ItemData item, int quantity) // I DONT KNOW WHAT THE FUCK IM DOING
    {
        //Debug.Log("itemName = " + itemName + "quantity = " + quantity + "itemObject = " + itemObject); //THIS MIGH BE A PROBLEM THERE IS NO SPRITE PICKUP ITS JUST THE ITEM OBJECT IDFK HOW THIS IS GOING TO WORK KMS KMS KMS KMS KMS KMS
        for (int i = 0; i < itemSlot.Length; i++)
        {
            //checks if theres leftover items
            //fix the itemslot to not search for the itemslot name cause it will check that and not the actual item oops itemSlot[i].name == name 
            if (!itemSlot[i].isFull && item == itemSlot[i].heldItem || itemSlot[i].quantity == 0) //ohhhh this was to check stackables, if the item picked up is the same as the one in the slot it should stack ontop
            {
                int leftOverItems = itemSlot[i].AddItem(item, quantity); //added item sprite for 2d inventory pop in
                if (leftOverItems > 0)
                { 
                    leftOverItems = AddItem(item, leftOverItems);
                }
                return leftOverItems;
            }
        }
        return quantity;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
