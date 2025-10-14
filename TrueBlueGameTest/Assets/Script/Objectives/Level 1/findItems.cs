using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findItems : Objective
{

    private Objective myObjective;

   // public List<TeleScript> houseTeleports = new();


    protected override void OnInitializeObjective()
    {
      
    }

    protected override void OnObjectiveUpdated()
    {

    }

    protected override void OnObjectiveCompleted()
    {
        Debug.Log("Completed!");

    }

   

    protected override void OnDestroy()
    {
        base.OnDestroy();
        myObjective.OnComplete -= OnObjectiveCompleted;
        
    }

}