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
    }
}