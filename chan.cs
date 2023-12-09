using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chan : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("UI");
    }
}
