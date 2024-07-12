using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] GameObject triggerObject;
    [SerializeField] GameObject warningObject;
    [SerializeField] GameObject spikeObject;
    private bool hasFallen = false;
    //EventTrigger eventTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerObject.GetComponent<EventTrigger>().GetTouchTrigger() == true && spikeObject.GetComponent<Spike>().GetFreeFromJail() == false) 
        { 
            GetComponent<Animator>().Play("FallingWall");
            hasFallen = true;
        }
        ActivateWarningSign();

        if (spikeObject.GetComponent<Spike>().GetFreeFromJail())
        {
            GetComponent<Animator>().Play("RisingWall");
        }
    }

    private void ActivateWarningSign()
    {
        if(hasFallen)
        {
            warningObject.SetActive(true);
        }
    }

    
    //public bool GetHasFallen() {  return hasFallen; }
}
