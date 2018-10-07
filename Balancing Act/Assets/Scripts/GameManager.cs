using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

public class GameManager : MonoBehaviour {
    bool gameOver = false;
    public float restartDelay;

    public GameObject showScoreUI;
    public GameObject timer;
    public GameObject endTimeText;

    private void Start()
    {
        Cursor.visible = false;
    }

    public void GameOver () {

        if(!gameOver)
        {
            gameOver = true;
            Time.timeScale = 1f;
            StartCoroutine(FindObjectOfType<BallGravity>().DetectOnScreen());
        }
	}

    void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void CompleteMenu()
    {
        Cursor.visible = true;
        float endTime = FindObjectOfType<TimerScript>().endTime;
        string textTime = FindObjectOfType<TimerScript>().textTime;
        endTimeText.GetComponent<TextMeshProUGUI>().text = textTime;
        showScoreUI.SetActive(true);
        timer.GetComponent<Animator>().enabled = true;
        saveHighScore(endTime);
    }

    public void PlayAgain()
    {
        Debug.Log("Play again");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartingMenu");
    }

    void saveHighScore(float endTime)
    {
        if(endTime > PlayerPrefs.GetFloat("highScore5", 0.0f))
        {
            string currentDate = DateTime.Now.Date.ToString("MM/dd/yyyy");
            
            string[] dates = new string[] {PlayerPrefs.GetString("highScoreDate1", "Date"),
                                        PlayerPrefs.GetString("highScoreDate2", "Date"),
                                        PlayerPrefs.GetString("highScoreDate3", "Date"),
                                        PlayerPrefs.GetString("highScoreDate4", "Date"),
                                        currentDate };

            float[] highs = new float[] {PlayerPrefs.GetFloat("highScore1", 0.0f),
                                        PlayerPrefs.GetFloat("highScore2", 0.0f),
                                        PlayerPrefs.GetFloat("highScore3", 0.0f),
                                        PlayerPrefs.GetFloat("highScore4", 0.0f),
                                        endTime };

            Array.Sort(highs, dates);
            Array.Reverse(highs);
            Array.Reverse(dates);

            PlayerPrefs.SetFloat("highScore1", highs[0]);
            PlayerPrefs.SetFloat("highScore2", highs[1]);
            PlayerPrefs.SetFloat("highScore3", highs[2]);
            PlayerPrefs.SetFloat("highScore4", highs[3]);
            PlayerPrefs.SetFloat("highScore5", highs[4]);
            PlayerPrefs.SetString("highScoreDate1", dates[0]);
            PlayerPrefs.SetString("highScoreDate2", dates[1]);
            PlayerPrefs.SetString("highScoreDate3", dates[2]);
            PlayerPrefs.SetString("highScoreDate4", dates[3]);
            PlayerPrefs.SetString("highScoreDate5", dates[4]);
        }
    }
}