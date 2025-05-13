using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class BattleStateMachine : MonoBehaviour
{

    public enum PerformAction
    {

        WAIT,
        TAKEACTION,
        PERFORMACTION,

    }

    public PerformAction battleStates;

    public List<HandleTurn> PerformList = new List<HandleTurn>();
    public List<GameObject> HerosInBattle = new List<GameObject>();
    public List<GameObject> EnemysInBattle = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemysInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        HerosInBattle.AddRange(GameObject.FindGameObjectsWithTag("Hero"));
    }

    // Update is called once per frame
    void Update()
    {
        switch(battleStates)
        {

            case (PerformAction.WAIT):
                if(PerformList.Count >0)
                {

                    battleStates = PerformAction.TAKEACTION;

                }
                break;

            case (PerformAction.TAKEACTION):
                GameObject performer = GameObject.Find(PerformList[0].Attacker);
                if(PerformList[0].Type == "Enemy")
                {

                    EnemyStateMachine ESM = performer.GetComponent<EnemyStateMachine>();
                    ESM.HeroToAttack = PerformList[0].AttackersTarget;
                    ESM.currentState = EnemyStateMachine.TurnState.ACTION;

                }

                if (PerformList[0].Type == "Hero")
                {



                }

                break;

            case (PerformAction.PERFORMACTION):

                break;


        }
    }

    public void CollectActions(HandleTurn input)
    {

        PerformList.Add(input);

    }

}
