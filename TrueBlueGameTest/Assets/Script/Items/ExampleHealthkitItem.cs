using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace TrueBlueGameTest.Assets.Script.Items
{
    [CreateAssetMenu(fileName ="Example Healthkit Item", menuName ="True Blue/Items/ExampleHealthkit")]
    public class ExampleHealthkitItem : ItemData
    {
        [SerializeField] private int healAmount = 100; 
    }
}