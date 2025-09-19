using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelEnd : MonoBehaviour
{
    public Canvas endCanvas;
    public TMP_Text endText;
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        
        endCanvas.enabled = false;
         //yield return new WaitForSeconds(2f);
        endText.enabled = false; 
         yield return new WaitForSeconds(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            endCanvas.enabled = true;
            yield return new WaitForSeconds(3f);
            endText.enabled = true;
            yield return new WaitForSeconds(7f);
            SceneManager.LoadScene(0);
        }

    }

}
