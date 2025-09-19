using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
    //Scriptable Object Script
{
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    //public AttributeToChange AttributeToChange = new AttributeToChange(); 
    //public int amountToChangeAttribute;


    //old code I need to remove but cant because apparently it is a pillar to this god forsaken inventory
    public bool UseItem()
    {
        if (statToChange == StatToChange.health)
        {

        }
        return false;
        // --------------------------------------------------------
    }

    public enum StatToChange //stat change list, easy to edit yummers!
    {
        none,
        health,
        insanity
    };

}

//I WANT THIS GONE BUT HOW IM GONNA KMS