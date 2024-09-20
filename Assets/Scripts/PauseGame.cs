using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Text pauseText;
    private float previousTimeScale = 1;

    void Start()
    {
        pauseText.text = "Press P to pause";
        pauseText.fontSize = 30;
        pauseText.transform.Translate(0.9f, -0.9f, 0);
        Time.timeScale = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
            
    }

    void TogglePause()
    {
        if(Time.timeScale > 0)
        {
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
            pauseText.text = "Pause";
            pauseText.fontSize = 100;
            pauseText.transform.Translate(-0.9f, 0.9f, 0);
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = previousTimeScale;
            pauseText.text = "Press P to pause";
            pauseText.fontSize = 30;
            pauseText.transform.Translate(0.9f, -0.9f, 0);
        }
    }
}
