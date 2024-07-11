using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLeft : MonoBehaviour
{
    Vector3 _initialPostion;
    [SerializeField] float _width = 7f;
    [SerializeField] float _speedX = 10f;

    void Start()
    {
        _initialPostion = transform.position;
    }

    void Update()
    {
        float x = _width * Mathf.Cos(Time.time * _speedX);
        transform.position = _initialPostion + Vector3.left * x;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
