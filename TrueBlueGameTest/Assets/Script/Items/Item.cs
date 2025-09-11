using System.Collections;
using System.Collections.Generic;
using TrueBlueGameTest.Assets.Script.Items;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ItemData heldItem;


    [SerializeField]
    private int quantity; // Field for item amount

    // ^^ Field for Item / this might be a problem that'll get messed with as again this was made for 2d and it'll feed to the addItem as the sprite. I'm sure it'll be a simple change?
    // Likely link sprites with objects in a sort of management script perhaps? Unsure lol idk how to code that well but I'd like 3d interactables and 2d sprites in the inventory like be so fr rn bro

    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>(); // Finds the Inventory Manager
    }

    public void Interact()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("I've been picked up!");
        }
    }

    //private void OnCollisionEnter(Collision collision) // Following the tutorial, this will likely need to severely edited cause unfortunately this was made for 2d but i'll splice it somehow lmao idk fuck it we ball
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        int leftOverItems = inventoryManager.AddItem(heldItem, quantity); // Originally ItemObject in the tutorial was a sprite, same for above. Will likely change to sprite when I figure out how the fuck that shit works lmao
    //        Debug.Log(leftOverItems);
    //        if (leftOverItems <= 0)
    //            Destroy(gameObject); // Destroys item object when no more left
    //        else
    //            quantity = leftOverItems;
    //
    //        //this makes me upset, it doesnt even kill the item anymore bruhtha
    //    }
    //}

}



