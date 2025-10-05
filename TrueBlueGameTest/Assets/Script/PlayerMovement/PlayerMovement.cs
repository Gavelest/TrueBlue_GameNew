using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class PlayerMovement : MonoBehaviour
{
    private InputHandler _input;

    //[SerializeField] private DialogueUI dialogueUI;

    [SerializeField]
    private bool RotateTowardMouse;

    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private float RotationSpeed;

    [SerializeField]
    private Camera Camera;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (dialogueUI.IsOpen) return;

        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        var movementVector = MoveTowardTarget(targetVector);

        if (!RotateTowardMouse)
        {
            RotateTowardMovementVector(movementVector);
        }
        if (RotateTowardMouse)
        {
            RotateFromMouseVector();
        }



    }

    private void RotateFromMouseVector()
    {
        if (Time.timeScale == 0)
            return;
        //capture the mouse position in screenspace
            //then scale the z offset to align it with the player's position - note that Camera.main is different from 'Camera'
        var screenspaceMousePosition = Input.mousePosition;
        screenspaceMousePosition.z = Vector3.Distance(Camera.main.transform.position, transform.position);

        //transform the mouse position into world space so that we can compare it to the player
        var worldspaceMousePosition = Camera.main.ScreenToWorldPoint(screenspaceMousePosition);

        //calculate the look direction as an offset from the player's position
        var lookDirection = worldspaceMousePosition - transform.position;
        lookDirection.y = 0; //clear anything on the y axis
        lookDirection.Normalize(); //convert to unit vector

        //Debug.DrawRay(transform.position, lookDirection);
        //apply to player
        transform.forward = lookDirection;
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
       
            var speed = MovementSpeed * Time.deltaTime;
        
        // transform.Translate(targetVector * (MovementSpeed * Time.deltaTime)); Demonstrate why this doesn't work
        //transform.Translate(targetVector * (MovementSpeed * Time.deltaTime), Camera.gameObject.transform);

        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if (movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }
}