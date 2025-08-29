using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
    //Scriptable Object Script
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    //public AttributeToChange AttributeToChange = new AttributeToChange(); 
    //public int amountToChangeAttribute;

    public bool UseItem()
    {
        //this will need to be edited depending on how the systems are set up!
        //likely will make a manager of some sort for each system, will have to collaborate with Cora :3

        //Duplicate the below code for each stat and change them for their corresponding components
        if (statToChange == StatToChange.health)
        {
            //PlayerHealth playerHealth = GameObject.Find("HealthManager").GetComponent<PlayerHealth>();
            //if(playerHealth.health == playerHealth.maxHealth //checks if player health full
            //{
            //  return false;
            //}
            //else
            //{
            //playerHealth.RestoreHealth(amountToChangeStat); //this searches for where x system is to pull from and change!
            //return true
            //}
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

    // public enum AttributeToChange //stat change list, easy to edit yummers!
    // {
    // none,
    // agility,
    // yourmother,
    //};
    //the commented out code is unnecessary for what we currently have but I thought I would include it in anyway, because honestly we could apply it somewhere if we wanted to!
    //could be cool for making certain things make you fucked up for a bit yknow?
}
