using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public string sceneName = "Title";
    public void LoadScene()
    {
        Debug.Log("Title");
        SceneManager.LoadScene(sceneName);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
