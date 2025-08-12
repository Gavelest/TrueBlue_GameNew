using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    public GameObject bullet;
    public float damage = 2f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    void OnTriggerEnter()
    {
        

    }
    
   IEnumerator DestroyCoroutine()
    {

        yield return new WaitForSeconds(3f);

        Destroy(bullet);
    }
    
}
