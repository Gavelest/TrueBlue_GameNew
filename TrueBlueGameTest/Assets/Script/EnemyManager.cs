using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private int maxHealth = 100;
    int curHealth;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

   
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bullet")
        {

            Debug.Log("Take Damage");
            //ChangeHealth();

        }

    }

    void ChangeHealth(int amount)
    {

        curHealth = Mathf.Clamp(curHealth + amount, 0, maxHealth);
        Debug.Log(curHealth + "/" + maxHealth);

    }

    
}
