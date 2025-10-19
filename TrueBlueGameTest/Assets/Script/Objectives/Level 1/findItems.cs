using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findItems : Objective
{

    private Objective myObjective;
    public List<Item> itemsGrabbed = new();


   // public List<TeleScript> houseTeleports = new();


    protected override void OnInitializeObjective()
    {

        foreach (Item t in itemsGrabbed) //subscribe to all teleporters activating for the first time
        {
            t.onFirstPickup += FirstGrabbedItem;
        }

        MaxValue = itemsGrabbed.Count;

    }

    protected override void OnObjectiveUpdated()
    {

    }

    protected override void OnObjectiveCompleted()
    {
        Debug.Log("Completed!");

    }

    private void FirstGrabbedItem() //trigger progress
    {
        AddProgress(1);
        Debug.Log("you got item first time!");
    }



    protected override void OnDestroy()
    {
        base.OnDestroy();
        myObjective.OnComplete -= OnObjectiveCompleted;
        foreach (Item t in itemsGrabbed)
        {
            t.onFirstPickup -= FirstGrabbedItem;
        }

    }

}