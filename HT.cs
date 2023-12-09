using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HT : MonoBehaviour
{
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadNextScene("SampleScene");
        }
        if (Input.GetMouseButton(0))
        {
            LoadNextScene("SampleScene");
        }
    }
    private void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
