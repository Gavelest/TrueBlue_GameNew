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

    private void Awake()
    {
        MainManager.Instance.PlayerController = this;
    }
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

    //Returns the change in health value
    public int ChangeHealth(int amount)
    {
        var old = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        healthText.text = $"{currentHealth} / {maxHealth}";
        return currentHealth - old;
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
