using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private TMP_Text healthText; 
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
        if(currentHealth <= 0)
        {

            Death();

        }
    }

    void ChangeHealth(int amount)
    {

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        healthText.text = $"{currentHealth} / {maxHealth}";
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Triggered by Enemy");
            ChangeHealth(-20);
        }

    }

    void Death()
    {

       SceneManager.LoadScene(0); 

    }

}
