using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

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

    public enum HeroGUI
    {

        ACTIVATE,
        WAITING,
        INPUT1,
        INPUT2,
        DONE

    }

    public HeroGUI HeroInput;

    public List<GameObject> HerosToManage = new List<GameObject>();
    private HandleTurn HeroChoice;

    public GameObject enemyButton;
    public Transform Spacer;

    public GameObject AttackPanel;
    public GameObject EnemySelectPanel;


    // Start is called before the first frame update
    void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemysInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        HerosInBattle.AddRange(GameObject.FindGameObjectsWithTag("Hero"));
        HeroInput = HeroGUI.ACTIVATE;

        AttackPanel.SetActive(false);
        EnemySelectPanel.SetActive(false);

        EnemyButtons();
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

        switch (HeroInput)
        {
            case (HeroGUI.ACTIVATE):
               /* if(HerosToManage.Count > 0)
                {

                    HerosToManage[0].transform.FindChild("Selector").gameObject.SetActive(true);
                    AttackPanel.SetActive(true);
                    HeroInput = HeroGUI.WAITING;

                }
               */

            case (HeroGUI.WAITING):
                break;

            case (HeroGUI.DONE):
                break;

        }

    }

    public void CollectActions(HandleTurn input)
    {

        PerformList.Add(input);

    }

    void EnemyButtons()
    {

        foreach(GameObject enemy in EnemysInBattle)
        {

            GameObject newButton = Instantiate(enemyButton) as GameObject;
            EnemySelectButton button = newButton.GetComponent<EnemySelectButton>();

            EnemyStateMachine cur_enemy = enemy.GetComponent<EnemyStateMachine>();

            Text buttonText = newButton.transform.Find("Text").gameObject.GetComponent<Text>();
            buttonText.text = cur_enemy.enemy.name;

            button.EnemyPrefab = enemy;

            newButton.transform.SetParent(Spacer);

        }

    }


}
