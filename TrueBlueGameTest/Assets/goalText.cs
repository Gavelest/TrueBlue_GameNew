using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class goalText : MonoBehaviour
{
    public Canvas goalCanvas;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        goalCanvas.enabled = false;
        yield return new WaitForSeconds(2f);
        goalCanvas.enabled = true;
        yield return new WaitForSeconds(3f);

        goalCanvas.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
