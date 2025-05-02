using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
   
    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleState state;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;


    // Start is called before the first frame update
    void Start()
    {

       state = BattleState.START;
       StartCoroutine(SetupBattle());


    }


    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = enemyUnit.unitName;

        playerHUD.SetHUD(playerUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    IEnumerator PlayerAttack()
    {

        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "that seemed to do something ";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {

            state = BattleState.WON;
            EndBattle();

        } else
        {

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }


    }

    IEnumerator EnemyTurn()
    {

        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        if(isDead)
        {

            state = BattleState.LOST;
            EndBattle();

        }else
        {

            state = BattleState.PLAYERTURN;
            PlayerTurn();

        }

    }

    void PlayerTurn()
    {

        dialogueText.text = "Choose an action:";

    }

    public void OnAttackButton()
    {

        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

    }

    IEnumerator PlayerHeal()
    {

        playerUnit.Heal(5);
        
        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());

    }

    public void OnHealButton()
    {

        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());

    }


    void EndBattle()
    {
        if(state == BattleState.WON)
        {

            dialogueText.text = "You survived";

        }else if (state == BattleState.LOST)
        {

            dialogueText.text = "You were torn to shreds.";

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
