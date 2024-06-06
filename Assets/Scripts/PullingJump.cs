using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 10f;
    Rigidbody rb;
    Vector3 clickPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb  = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (Input.GetMouseButtonDown(0)) //when we press left mouseclick
        {
            clickPosition = Input.mousePosition; //take the position where we clicked

        }
        if (Input.GetMouseButtonUp(0)) //when not pressing left mouseclick
        {

            Vector3 dragVector = clickPosition - Input.mousePosition; //calculate distance between where we clicked and released

            float size = dragVector.magnitude; //get the length of the vector

            rb.velocity = dragVector.normalized * jumpSpeed;

        }
    }
}
