using Core.Gameplay.Objectives;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _objectiveText;

    private Objective _objective;

    public void Init(Objective objective)
    {
        _objective = objective;
        _objectiveText.text = objective.GetStatusText();
        objective.OnValueChange += OnObjectiveValueChange;
        objective.OnComplete += OnObjectiveComplete;
    }

    private void OnObjectiveComplete()
    {
        _objectiveText.text = $"<s>{_objective.GetStatusText()}</s>";
    }

    private void OnObjectiveValueChange()
    {
        _objectiveText.text = _objective.GetStatusText();
    }
}
