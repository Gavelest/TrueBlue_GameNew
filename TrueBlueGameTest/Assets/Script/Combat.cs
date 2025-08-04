using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;

    [SerializeField] private GameObject projectilePrefab;
    private float bulletCount = 6f;
    private float bulletMin = 1f;

    public Vector3 worldPosition;
    public Vector3 screenPosition;
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

            screenPosition = Input.mousePosition;
            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);


            var bullet = Instantiate(projectilePrefab, transform.position, transform.rotation);

        }

    }


}
