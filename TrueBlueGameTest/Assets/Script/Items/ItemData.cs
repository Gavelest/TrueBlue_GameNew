using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace TrueBlueGameTest.Assets.Script.Items
{


    public abstract class ItemData : ScriptableObject
    {
        public string itemName; // Field for name (obviously lol)
        public string description; // Field for desc (obviously lol)
        public Sprite icon; // Field for description icon
        public Sprite slotIcon; // This is what holds the icon for the item in an inventory slot



    }

    //public bool SanityHeal()
    //{
    //    if (InventoryManager.UseItem)
    //        sanitySlider.value + InsanityhealAmount;
    //}
    //return false;

}

//Items needed
//healing, insanity, key(?)
//make a part for right click use within... here???? oops

//go off and find all the prev old pass variables and change them to item held item stuff idk go brr bro you got it

//ok so like, a lot of the functionality (sort of) is already on the item slot, im gonna scream idk how to freehand this


//This works theoretically, however, with the problem that is needing a 'UseItem' class in here is the major problem child
//Because Idk wtf should bool in the statement