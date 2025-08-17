using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName; // Field for name (obviously lol)

    [SerializeField]
    private int quantity; // Field for item amount

    [SerializeField]
    private GameObject ItemObject; 
    // ^^ Field for Item / this might be a problem that'll get messed with as again this was made for 2d and it'll feed to the addItem as the sprite. I'm sure it'll be a simple change?
    // Likely link sprites with objects in a sort of management script perhaps? Unsure lol idk how to code that well but I'd like 3d interactables and 2d sprites in the inventory like be so fr rn bro

    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>(); // Finds the Inventory Manager
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision) // Following the tutorial, this will likely need to severely edited cause unfortunately this was made for 2d but i'll splice it somehow lmao idk fuck it we ball
    {
        if(collision.gameObject.tag == "Player")
        {
            inventoryManager.AddItem(itemName, quantity, ItemObject); // Originally ItemObject in the tutorial was a sprite, same for above. Will likely change to sprite when I figure out how the fuck that shit works lmao
            Destroy(gameObject); // Destroys item object on collision pickup
            Debug.Log("I've been picked up!");
            //Thing can't be picked up at the moment because player collision is screwed
            //also no collision is working on the the object either??? the pivot is fuckin somewhere weird like what
            //THEORETICALLY THO Daniel says it should work if the player works
        }
    }

}
