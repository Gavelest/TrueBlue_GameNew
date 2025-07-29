using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnlockMouse();
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UnlockMouse()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

}
