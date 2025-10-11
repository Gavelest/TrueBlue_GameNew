using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace TrueBlueGameTest.Assets.Script.Items
{


    [CreateAssetMenu(fileName = "Insanity Heal Item", menuName = "True Blue/Items/InsanityHealItem")]
    public class InsanityHealthItem : ItemData
    {

        [SerializeField] private int InsanityhealAmount = 100;

        //make it so the the player can't heal if they are full
        public override bool UseItem()
        {
            return true;
        }
    }

    
}




//public override bool UseItem() //make it so the the player can't heal if they are full
//{
//    if (Input.GetMouseButtonDown(1)) //uses item with right click
//    {
//        int newValue = (fullSanity + InsanityhealAmount);
//        Debug.Log("player SANITY healed!");
//   }

//    else
//    {
//        return false;
//    }

//}

//this wont actually do anything until a insanity manager is created
//which in itself shouldn't be too hard because it'll be built off the health manager and we can go from there THEORETICALLY