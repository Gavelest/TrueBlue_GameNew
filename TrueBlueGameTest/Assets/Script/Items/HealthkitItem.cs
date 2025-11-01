using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace TrueBlueGameTest.Assets.Script.Items
{
    [CreateAssetMenu(fileName = "Healthkit Item", menuName = "True Blue/Items/Healthkit")]
    public class HealthkitItem : ItemData
    {
        [SerializeField] private int healAmount = 100;

        private InventoryManager inventoryManager;

        //make it so the the player can't heal if they are full
        public override bool UseItem()
        {
            var healthChange = MainManager.Instance.PlayerController.ChangeHealth(healAmount);
            //return healthChange > 0;
            return true;
        }
    }
}

// have to mess with the function of this with the health manager