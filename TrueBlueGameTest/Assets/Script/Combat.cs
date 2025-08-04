using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;

    [SerializeField] private GameObject projectilePrefab;
    private float bulletCount = 6f;
    private float bulletMin = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
         if (Input.GetKeyDown(KeyCode.Mouse1))
         {
            GunShot();
         }
        

    }

    void GunShot()
    {

         if (bulletCount < bulletMin)
        {

                print("no bullets");

        }
        else
        {

            Vector3 mousePos = Input.mousePosition;

            var bullet = Instantiate(projectilePrefab, transform.position, transform.rotation);

        }

    }


}
