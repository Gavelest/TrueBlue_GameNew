using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveFarm : MonoBehaviour
{
    public TMP_Text ObjFarm;

    // Start is called before the first frame update
    void Start()
    {
        ObjFarm.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            ObjFarm.enabled = true;
        }
    }

}
