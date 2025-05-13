using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{

    private BattleStateMachine BSM;
    public BaseEnemy enemy;

    public enum TurnState
    {

        PROCESSING,
        CHOOSEACTION,
        WAITING,
        ACTION,
        DEAD,

    }

    public TurnState currentState;

    private float cur_cooldown = 0f;
    private float max_cooldown = 5f;

    private Vector3 startposition;

    private bool actionStarted = false;
    public GameObject HeroToAttack;
    private float animSpeed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnState.PROCESSING;
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        startposition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {

            case (TurnState.PROCESSING):
                UpgradeProgressBar();
                break;

            case (TurnState.CHOOSEACTION):
                ChooseAction();
                currentState = TurnState.WAITING;
                break;

            case (TurnState.WAITING):

                break;

            case (TurnState.ACTION):
                StartCoroutine(TimeForAction());
                break;

            case (TurnState.DEAD):

                break;

        }

        void UpgradeProgressBar()
        {

            cur_cooldown = cur_cooldown + Time.deltaTime;
            
            if (cur_cooldown >= max_cooldown)
            {

                currentState = TurnState.CHOOSEACTION;

            }

        }

    }

    void ChooseAction()
    {

        HandleTurn myAttack = new HandleTurn();
        myAttack.Attacker = enemy.name;
        myAttack.Type = "Enemy";
        myAttack.AttackersGameObject = this.gameObject;
        myAttack.AttackersTarget = BSM.HerosInBattle[Random.Range(0, BSM.HerosInBattle.Count)];
        BSM.CollectActions(myAttack);

    }

    private IEnumerator TimeForAction()
    {

        if(actionStarted)
        {

            yield break;

        }

        actionStarted = true;

        Vector3 heroPosition = new Vector3(HeroToAttack.transform.position.x - 1.5f, HeroToAttack.transform.position.y, HeroToAttack.transform.position.z);
        while(MoveTowardsEnemy(heroPosition))
        {

            yield return null;

        }

        actionStarted = false;

        cur_cooldown = 0f;

    }

    private bool MoveTowardsEnemy(Vector3 target)
    {

        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));

    }


}
