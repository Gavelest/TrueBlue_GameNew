using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Gameplay.Objectives
{ 
    public class Objective : MonoBehaviour
    {
        public Action OnComplete; //when an objective is completed do...
        public Action OnValueChange; //When any progress on an objective is made do...

        // Used to AddProgress from ObjectiveManager.
        // Can be empty if objective progress is managed elsewhere.
        public string EventTrigger { get; }
        public bool IsComplete { get; private set; }
        public int MaxValue { get; }
        public int CurrentValue { get; private set; }

        private readonly string _statusText;

        // Status text can have 2 parameters {0} and {1} for current and max value
        // Example: "Kill {0} of {1} enemies"
        public Objective(string eventTrigger, string statusText, int maxValue)
        {
            EventTrigger = eventTrigger;
            _statusText = statusText;
            MaxValue = maxValue;
        }

        public Objective(string statusText, int maxValue) : this("", statusText, maxValue) { }
        //probably not the best

        private void CheckCompletion()
        {
            if (CurrentValue >= MaxValue)
            {
                IsComplete = true;
                OnComplete?.Invoke();
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
        }

        public string GetStatusText()
        {
            return string.Format(_statusText, CurrentValue, MaxValue);
        }
    }
}
//Notes
//This script carries and represents the single individual objective within the game
//This is better for smaller objectives that aren't going to be a global across the whole game objective
//We'll probably just use the the manager tho

//edit of https://www.jonathanyu.xyz/2023/11/29/dynamic-objective-system-tutorial-for-unity