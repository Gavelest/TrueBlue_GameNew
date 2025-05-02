using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public spiderUnit Spider;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, spiderContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Update()
    {


    }

}
