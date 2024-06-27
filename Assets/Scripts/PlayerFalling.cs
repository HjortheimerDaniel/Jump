using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFalling : MonoBehaviour
{
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerIsFalling();
    }

    public bool PlayerIsFalling()
    {
        if (rb.position.y <= -4f)
        {
            Debug.Log("Test");
            return true;
        }
        return false;
    }
}
