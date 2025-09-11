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
        public string description; // Field for name (obviously lol)
        public Sprite icon; // Field for icon EXCEPT IT DOESNT FUCKING WORK
        public int quanity;

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