using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TA : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
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
