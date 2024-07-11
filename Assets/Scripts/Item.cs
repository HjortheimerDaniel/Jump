using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    Animator animator;
    [SerializeField] Text text;
    private int maxCoins = 3;
    private int takenCoins = 0;
    AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>(); //take the component from where this scrips is attached to
        audioSource = GetComponent<AudioSource>();
        takenCoins = 0;
    }

    void Update()
    {
        //if(Input.GetKeyUp(KeyCode.E))
        //{
        //    animator.Play("Idle");
        //}
        AllCoinsTaken();


    }

    void OnGetAnimationFinshed() //when we have done the animation once
    {
        Destroy(gameObject); //destroy it
    }

    private void OnTriggerEnter(Collider other) //when we pass through a trigger
    {
        //Add drag when touching the object

        //Rigidbody rb = other.GetComponent<Rigidbody>();
        //rb.drag = 15;
        // animator.Play("Get");

        //Debug.Log(other.gameObject.name + " Is inside you");
        animator.SetBool("IsGet", true);
        takenCoins++;
        Debug.Log(takenCoins);
        audioSource.Play();
        
    }

    private void OnTriggerExit(Collider other)
    {
        //Rigidbody rb = other.GetComponent<Rigidbody>();
        //rb.drag = 0;
        //Debug.Log(other.gameObject.name + " Is no longer inside you");
    }

    public bool AllCoinsTaken()
    {
        if(takenCoins == maxCoins)
        {
            return true;
        }
        return false;
    }
}
