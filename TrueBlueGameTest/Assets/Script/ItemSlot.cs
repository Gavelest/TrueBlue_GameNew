using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //Item Data - stores data - set public for debug purposes ========================
    public string itemName;
    public int quantity;
    public GameObject itemObject;
    public Sprite itemSprite; //m
    public bool isFull; //tracks if slot full
    public string itemDescription;
    public Sprite emptySprite; //makes it so the empty slots have an invisible item image instead of glaring bright white default, im pretty sure the easier way of doing this is to set the description image to a bool but im following a tutorial ew

    [SerializeField]
    private int maxNumberOfItems; //defines the size of the slot

    //Item Slot- display data ==========================
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    //Item Description area ===================================
    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    //Stuff ========================================
    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    //Actual Code things ========================================
    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, GameObject itemObject, string itemDescription, Sprite itemSprite) //m
    {
        //Check to see if slot is full
        if (isFull)
            return quantity;
        
        //update name
        this.itemName = itemName;

        //update item object
        this.itemObject = itemObject;

        //update description
        this.itemDescription = itemDescription;

        //update item image sprite
        this.itemSprite = itemSprite; //m
        itemImage.enabled = true;

        //update quantity
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;
        

        //Return the leftovers
        int extraItems = this.quantity - maxNumberOfItems;
        this.quantity = maxNumberOfItems;
        return extraItems;
        }

        //Update Quantity Text
        quantityText.text= this.quantity.ToString();
        quantityText.enabled = true;
        return 0;

    }

    public void OnPointerClick(PointerEventData eventData) //method for calling item clicked
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots(); //deselects slots before selecting a new one
        selectedShader.SetActive(true);
        thisItemSelected = true;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite; //shit

        if (itemDescriptionImage.sprite == null)
            itemDescriptionImage.sprite = emptySprite;
    }

    public void OnRightClick()
    {

    }

}
