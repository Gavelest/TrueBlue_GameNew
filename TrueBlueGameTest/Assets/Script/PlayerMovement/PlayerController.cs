using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeHealth(int amount)
    {

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Triggered by Enemy");
            ChangeHealth(-20);
        }

    }
}
