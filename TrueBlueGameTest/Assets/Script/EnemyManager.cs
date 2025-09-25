using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public int maxHealth = 100;
    int curHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(curHealth <= 0)
        {
            Destroy(gameObject);
            

        }
        else
        {



        }
    }

   
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Bullet")
        {

            Debug.Log("Take Damage");
            ChangeHealth(-50);

        }

    }

    void ChangeHealth(int amount)
    {

        curHealth = Mathf.Clamp(curHealth + amount, 0, maxHealth);
        

    }
   

    
}
