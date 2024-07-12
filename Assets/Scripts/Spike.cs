using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spike : MonoBehaviour
{
    [SerializeField] GameObject warningObject;
    private bool touched = false;
    private bool secondAnimation = false;
    private bool freeFromJail = false;

    private void Start()
    {
        
    }
    private void Update()
    {
        SpikeFalling();
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        touched = true;
    }

    void SpikeFalling()
    {
        if(warningObject.GetComponent<Warning>().GetWarning() == 2 && !secondAnimation)
        {
            GetComponent<Animator>().Play("FallingSpike");
        }

        if(warningObject.GetComponent<Warning>().GetWarning() == 2 && secondAnimation)
        {
            GetComponent<Animator>().Play("FallingSpike2");
        }
    }

    void ResetWarnings()
    {
        warningObject.GetComponent<Warning>().SetWarning(0);
        secondAnimation = true;
    }

    public bool GetIsTouched() {  return touched; }

    void MoveWarningSprite()
    {
        
        warningObject.GetComponent<Warning>().MoveToRight();
    }

    public void AnimationFinished()
    {
        freeFromJail = true;
    }

    public bool GetFreeFromJail() { return freeFromJail; }

   
}
