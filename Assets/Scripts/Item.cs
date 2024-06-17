using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //when we pass through a trigger
    {
        //Add drag when touching the object

        //Rigidbody rb = other.GetComponent<Rigidbody>();
        //rb.drag = 15;

        Debug.Log(other.gameObject.name + " Is inside you");
        //Destroy(gameObject); //destroy it

    }

    private void OnTriggerExit(Collider other)
    {
        //Rigidbody rb = other.GetComponent<Rigidbody>();
        //rb.drag = 0;
        Debug.Log(other.gameObject.name + " Is no longer inside you");

    }
}
