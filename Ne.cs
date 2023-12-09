using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ne : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("How");
    }
}
