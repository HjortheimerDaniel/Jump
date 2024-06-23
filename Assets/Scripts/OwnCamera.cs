using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OwnCamera : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    Vector3 clickPosition;
    private bool isDragging;


    private void Awake()
    {
       //Camera.main.gameObject.TryGetComponent<CinemachineBrain>(out var brain);
       //if (brain != null)
       //{
       //    brain = Camera.main.gameObject.AddComponent<CinemachineBrain>();
       //}
        _virtualCamera = gameObject.GetComponent<CinemachineVirtualCamera>();
        //comp.m_BiasX
        //_virtualCamera
        CameraStartPos();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // When we press left mouse button
        {
            clickPosition = Input.mousePosition; // Take the position where we clicked
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0)) // When we release the left mouse button
        {
            isDragging = false;

        }

        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition; // Get the current mouse position
            Vector3 dragVector = currentMousePosition - clickPosition; // Calculate the drag vector

            // Adjust the camera bias based on the drag direction
            if (clickPosition.x < currentMousePosition.x && _virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.x > -5)
            {
                _virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.x -= 0.1f;
            }

            if(clickPosition.x > currentMousePosition.x && _virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.x < 5)
            {
                _virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.x += 0.1f;
            }
            //clickPosition = currentMousePosition; // Update the click position for continuous dragging

            Debug.Log(currentMousePosition);
        }
        else
        {
            ResetCameraPos();
        }

    }

    void CameraStartPos()
    {
        _virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.x = 0.0f;
    }

    void ResetCameraPos()
    {
        if (!isDragging && _virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.x < 0.0f)
        {
            _virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.x += 0.1f;

        }

        if (!isDragging && _virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.x > 0.0f)
        {
            _virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.x -= 0.1f;

        }
    }
}

