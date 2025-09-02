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
    }
}

//this wont actually do anything until a insanity manager is created
//which in itself shouldn't be too hard because it'll be built off the health manager and we can go from there THEORETICALLY