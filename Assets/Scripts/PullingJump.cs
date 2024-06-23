using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float groundAngleLimit = 30f;
    Rigidbody rb;
    Vector3 clickPosition;
    bool canJump = false;
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
        if (canJump && Input.GetMouseButtonUp(0)) //when not pressing left mouseclick
        {

            Vector3 dragVector = clickPosition - Input.mousePosition; //calculate distance between where we clicked and released

            float size = dragVector.magnitude; //get the length of the vector

            rb.velocity = dragVector.normalized * jumpSpeed;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;
        var rend = obj.gameObject.GetComponent<Renderer>();
        var mat = rend.material;
        mat.color = Color.yellow;
        rend.material = mat;
        //if(collision.gameObject.tag == "Ground")
        //{



        Vector3 normal = collision.contacts[0].normal; //ñ@ê¸ÇéÊÇ¡ÇƒÇ¢Ç≠

        float angle = Vector3.Angle(normal, Vector3.up); //get the difference of the angle between what we collided with and a line that goes straight up

        if (angle < groundAngleLimit) //if the difference is less than 30 degrees
        {
            canJump = true;
        }

        //}
        Debug.Log(collision.gameObject.name + "test3");

    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal; //ñ@ê¸ÇéÊÇ¡ÇƒÇ¢Ç≠

        float angle = Vector3.Angle(normal, Vector3.up); //get the difference of the angle between what we collided with and a line that goes straight up

        if (angle < groundAngleLimit) //if the difference is less than 30 degrees
        {
            canJump = true;
        }


        //Debug.Log("test3");

    }

    
}
