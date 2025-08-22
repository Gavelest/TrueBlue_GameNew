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

    [SerializeField] //Me attempting to make my own code so im commenting the pseudopart here, I just need this so the image can be appart of the object or something
    private Sprite itemSprite; //m

    [TextArea]
    [SerializeField]
    private string itemDescription;

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
            
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, ItemObject, itemDescription, itemSprite); // Originally ItemObject in the tutorial was a sprite, same for above. Will likely change to sprite when I figure out how the fuck that shit works lmao
            Debug.Log(leftOverItems);
            if (leftOverItems <= 0)
                Destroy(gameObject); // Destroys item object when no more left
            else
                quantity = leftOverItems;


            //if you would like to to debug please change the above code to just be what is below, it'll check if the item is getting picked up
            // inventoryManager.AddItem(itemName, quantity, ItemObject, itemDescription, itemSprite);
            // Destroy(gameObject);
            // Debug.Log("I've been picked up!");

                //Thing can't be picked up at the moment because player collision is unfortunately screwed atm
                //also no collision is working on the the object either??? the pivot is fuckin somewhere weird like what
                //THEORETICALLY THO Daniel says it should work if the player works
                //update -> despite movement being fixed the collision is still the bigger problem, but again theoretically this code should work once collision is working properly
        }
    }

}
