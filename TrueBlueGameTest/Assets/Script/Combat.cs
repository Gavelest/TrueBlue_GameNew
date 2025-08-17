using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;

    [SerializeField] private GameObject projectilePrefab;
    private float bulletCount = 6f;
    private float bulletMin = 1f;

    private Vector3 playerPose;

    public Vector3 worldPosition;
    public Vector3 screenPosition;

    public float shootForce = 20f;
    public float fireRate = 0.5f;

    public Rigidbody projectile;
    public float speed = 20;
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
            var worldSpaceMousePos = Camera.main.ScreenToWorldPoint(screenPosition);

            Vector3 playerAimDirection = transform.position - worldSpaceMousePos;
            playerAimDirection = new Vector3(playerAimDirection.x, 0, playerAimDirection.z).normalized;

            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;

            instantiatedProjectile.velocity = playerAimDirection * speed;

            bulletCount--;


        }
        

    }


}
