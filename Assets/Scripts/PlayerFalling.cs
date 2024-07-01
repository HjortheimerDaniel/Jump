using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFalling : MonoBehaviour
{
    public Rigidbody _rb;
    private GameObject _gameObject;
    private Vector3 _lastKnownPosition;
    private bool _resetBool;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _gameObject = _rb.gameObject;
        _resetBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerIsFalling();
    }

    public bool PlayerIsFalling()
    {
        if (_rb.position.y <= -4f)
        {
            //Debug.Log("Test");
            _lastKnownPosition = _rb.position; //save the last position before we set it as inactive
            gameObject.SetActive(false);
            _resetBool = true;
            
            return true;
        }
        return false;
    }
    

    public Vector3 GetLastKnownPosition()
    {
        return _lastKnownPosition;
    }

    public bool GetResetBool () 
    { 
        return _resetBool;
    }  
}
