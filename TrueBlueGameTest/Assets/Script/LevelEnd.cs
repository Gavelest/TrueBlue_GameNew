using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelEnd : MonoBehaviour
{
    public Canvas levelEnd;
    public TextMeshProUGUI endText;

    // Start is called before the first frame update
    void Start()
    {
        levelEnd.enabled = false;
        endText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter(Collider collider)
    {

              if (collider.gameObject.tag == "Player")
        {
           levelEnd.enabled = true;
            yield return new WaitForSeconds(3f);
            endText.enabled = true;
        }
    }
}
