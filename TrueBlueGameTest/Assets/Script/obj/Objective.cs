using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public abstract class Objective : MonoBehaviour
{
    // Invoked when the objective is completed
    public Action OnComplete;
    // Invoked when the objective's progress changes
    public Action OnValueChange;  // Used to AddProgress from ObjectiveManager.
                                  // Can be empty if objective progress is managed elsewhere.
    [field:SerializeField] public string EventTrigger { get; protected set;}
    public bool IsComplete { get; private set; }
    [field:SerializeField] public int MaxValue { get; protected set;}
    public int CurrentValue { get; private set; }
    [field:SerializeField] public string Status { get; protected set;}  // Status text can have 2 parameters {0} and {1} for current and max value
                                          // Example: "Kill {0} of {1} enemies"
  
    protected abstract void OnInitializeObjective();

    protected abstract void OnObjectiveUpdated();

    protected abstract void OnObjectiveCompleted();

    private void Start() 
    {
        MainManager.Instance.ObjectiveManager.AddObjective(this);
        OnInitializeObjective();
    }


    private void CheckCompletion()
    {
        if (CurrentValue >= MaxValue)
        {
            IsComplete = true;
            OnComplete?.Invoke();
            OnObjectiveCompleted();
        }
    }
    public void AddProgress(int value)
    {
        if (IsComplete)
        {
            return;
        }
        CurrentValue += value;
        if (CurrentValue > MaxValue)
        {
            CurrentValue = MaxValue;
        }
        OnValueChange?.Invoke();
        CheckCompletion();
        OnObjectiveUpdated();
    }
    public string GetStatusText()
    {
        return string.Format(Status, CurrentValue, MaxValue);
    }


    protected virtual void OnDestroy() 
    {
        MainManager.Instance.ObjectiveManager.Objectives.Remove(this);
    }

}


