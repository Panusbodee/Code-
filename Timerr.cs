using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timerr : MonoBehaviour
{
    public float WaitSec;
    private int WaitSecInt;
    public Text text;
    private bool stopTimer = false;

    private int collectedGems = 0;

    private void FixedUpdate()
    {
        if (!stopTimer && WaitSec > 0)
        {
            WaitSec -= Time.fixedDeltaTime;
            WaitSecInt = (int)WaitSec;
            text.text = WaitSecInt.ToString();
        }
        else
        {
            if (collectedGems >= 5)
            {
                LoadNextScene();
            }
            else
            {
                SceneManager.LoadScene("Gameover");
            }
        }
    }

    // เมื่อเก็บคะแนน
    public void CollectGem()
    {
        collectedGems++;

        // ถ้าเก็บครบ 5 ให้หยุดจับเวลา
        if (collectedGems >= 5)
        {
            stopTimer = true;
        }
    }

    // โหลดฉากถัดไป
    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
