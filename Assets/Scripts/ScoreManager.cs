using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    private int score1 = 0;
    private int score2 = 0;
    public int finalScore = 3;
    public int ExitSceneID = 3;

    public Text score1text;
    public Text score2text;

    public void goal1()
    {
        score1++;
        score1text.text = score1.ToString();
        CheckScore();
    }

    public void goal2()
    {
        score2++;
        score2text.text = score2.ToString();
        CheckScore();
    }

    private void CheckScore()
    {
        if(score1 == finalScore || score2 == finalScore)
            SceneManager.LoadScene(ExitSceneID);
    }
}
