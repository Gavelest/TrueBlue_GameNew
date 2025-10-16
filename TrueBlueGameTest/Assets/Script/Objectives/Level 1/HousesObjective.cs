using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousesObjective : Objective
{

    private Objective myObjective;

    public List<TeleScript> houseTeleports = new();
    public GameObject invisWall;


    protected override void OnInitializeObjective()
    {
        foreach(TeleScript t in houseTeleports) //subscribe to all teleporters activating for the first time
        {
            t.OnPlayerFirstTeleported += OnHouseFirstEntered;
        }

        MaxValue = houseTeleports.Count;
    }

    protected override void OnObjectiveUpdated()
    {

    }

    protected override void OnObjectiveCompleted()
    {
        Debug.Log("Completed!");
        invisWall.SetActive(false);

        
    }

    private void OnHouseFirstEntered() //trigger progress
    {
        AddProgress(1);
        Debug.Log("Entered a house!");
    }

    protected override void OnDestroy() 
    {
        base.OnDestroy();
        myObjective.OnComplete -= OnObjectiveCompleted;
        foreach(TeleScript t in houseTeleports)
        {
            t.OnPlayerFirstTeleported -= OnHouseFirstEntered;
        }
    }

}
