using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ParticleScript : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private Rigidbody _rb;
    [SerializeField] PlayerFalling _playerFalling;
    private Transform _transform;
    private bool hasPlayed;
    private int _resetTimer;
    
    // Start is called before the first frame update
    void Start()
    {
       _particleSystem = GetComponent<ParticleSystem>();
       _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        hasPlayed = false;
        _resetTimer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        StartParticles();
        ResetStage();
    }

   private void StartParticles()
    {
        if (_playerFalling == null) return;
       

        if (!_playerFalling.gameObject.activeSelf && !hasPlayed)
        {
            _transform.position = _playerFalling.GetLastKnownPosition();
            _particleSystem.Play();
            hasPlayed = true;
        }
    }

    private void ResetStage()
    {
        if (_playerFalling.GetResetBool())
        {
            _resetTimer ++;
        }
        if (_resetTimer >= 60 || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
