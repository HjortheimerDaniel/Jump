using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string sceneName = "SampleScene";
    public void LoadScene()
    {
        Debug.Log("Load Scene");
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
