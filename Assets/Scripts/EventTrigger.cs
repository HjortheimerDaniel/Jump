using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    private bool touchTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       touchTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetTouchTrigger() { return touchTrigger; }
}
