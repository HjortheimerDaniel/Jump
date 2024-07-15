using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ParticleScriptCrushed : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private Rigidbody _rb;
    [SerializeField] PlayerCrushed playerCrushed_;

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
        if (playerCrushed_ == null) return;


        if (playerCrushed_.GetResetBool() && !hasPlayed)
        {
            _transform.position = playerCrushed_.GetLastKnownPosition();
            //Debug.Log($"Player crushed at position: {playerCrushed_.GetLastKnownPosition()}");
            //_particleSystem.Stop();
            _particleSystem.Play();
            //Debug.Log("Particle system started at the correct position.");
            hasPlayed = true;
        }
    }

    private void ResetStage()
    {
        if (playerCrushed_.GetResetBool())
        {
            _resetTimer++;
        }
        if (_resetTimer >= 60 || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
