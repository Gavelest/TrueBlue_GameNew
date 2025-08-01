using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{


    public GameObject projectile;
    private bool bulletCount = 6f;
    private bool bulletMin = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       

        if (bulletCount < bulletMin)
        {



        }
        else();
        {

            if (Input.GetButtonDown(KeyCode.Mouse1));
            Instantiate(projectile, transform.position, transform.rotation);

        }

    }
}
