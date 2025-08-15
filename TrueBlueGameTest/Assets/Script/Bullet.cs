using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    public GameObject bullet;
    public float damage = 2f;
    //public EnemyManager enemy;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Triggered by Enemy");


        }
        //Destroy(this.gameObject);

    }

    IEnumerator DestroyCoroutine()
    {

        yield return new WaitForSeconds(3f);

        Destroy(bullet);
    }
    

    
}
