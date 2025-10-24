using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueObjective : Objective
{
    private Objective myObjective;
    public List<DialogueActivator> spokenToo = new();



    protected override void OnInitializeObjective()
    {
        foreach (DialogueActivator t in spokenToo) //subscribe to all teleporters activating for the first time
        {
            t.onPlayerFirstSpokenToo += OnFirstDialogue;
        }

        MaxValue = spokenToo.Count;

    }

    protected override void OnObjectiveUpdated()
    {

    }

    protected override void OnObjectiveCompleted()
    {
        Debug.Log("Completed!");
        


    }

    private void OnFirstDialogue() //trigger progress
    {
        AddProgress(1);
        Debug.Log("Spoken to character!");
    }



    protected override void OnDestroy()
    {
        base.OnDestroy();
        myObjective.OnComplete -= OnObjectiveCompleted;
        
    }


}
