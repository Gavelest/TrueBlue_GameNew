using System.Collections;
using System.Collections.Generic;
using TrueBlueGameTest.Assets.Script.Items;
using UnityEngine;
using System;

    


public class Item : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ItemData heldItem;

    public Action onItemPickup;
    public Action onFirstPickup;

    private bool hasBeenPickedUp;


    [SerializeField]
    private int quantity; // Field for item amount

    // ^^ Field for Item / this might be a problem that'll get messed with as again this was made for 2d and it'll feed to the addItem as the sprite. I'm sure it'll be a simple change?
    // Likely link sprites with objects in a sort of management script perhaps? Unsure lol idk how to code that well but I'd like 3d interactables and 2d sprites in the inventory like be so fr rn bro

    private InventoryManager inventoryManager;

    public void Interact(Player player)
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>(); // Finds the Inventory Manager
    }

    public void Interact()
    {
            Debug.Log("I've been picked up!");
            int leftOverItems = inventoryManager.AddItem(heldItem, quantity); 
            Debug.Log(leftOverItems);
            if (leftOverItems <= 0)
                Destroy(gameObject); // Destroys item object when no more left
            else
                quantity = leftOverItems;

            onItemPickup?.Invoke();
            if (!hasBeenPickedUp)
            {
                hasBeenPickedUp = true;
                onFirstPickup?.Invoke();
            }

    }

}

//when making new items please make sure their colliders are in the floor due to the raycast being below the feet of the character


