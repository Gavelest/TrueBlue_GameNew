using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Gameplay.Objectives
{ 
    public class ObjectiveManager : MonoBehaviour
    {
        public Action<Objective> OnObjectiveAdded;

        public List<Objective> Objectives { get; } = new();

        private readonly Dictionary<string, List<Objective>> _objectiveMap = new();

        // Adds an objective to the objective manager.
        // If the objective has an EventTrigger, it's progress will be incremented
        // by AddProgress when the event is triggered. Multiple objectives can have
        // the same EventTrigger (i.e. MobKilled, ItemCollected, etc)
        public void AddObjective(Objective objective)
        {
            Objectives.Add(objective);
            if (!string.IsNullOrEmpty(objective.EventTrigger))
            {
                if (!_objectiveMap.ContainsKey(objective.EventTrigger))
                {
                    _objectiveMap.Add(objective.EventTrigger,
                                      new List<Objective>());
                }

                _objectiveMap[objective.EventTrigger].Add(objective);
            }

            OnObjectiveAdded?.Invoke(objective);
        }

        public void AddProgress(string eventTrigger, int value)
        {
            if (!_objectiveMap.ContainsKey(eventTrigger))
                return;
            foreach (var objective in _objectiveMap[eventTrigger])
            {
                objective.AddProgress(value);
            }
        }
    }
}
//This is where the actual objectives and progress is made and added
//The manager of objectives and progress

//edit of https://www.jonathanyu.xyz/2023/11/29/dynamic-objective-system-tutorial-for-unity
//code tests to look at https://github.com/xjjon/unity-objective-system/tree/master/Editor/Tests

//still disecting the code to understand it but its 4am and my brain is starting to malfunction