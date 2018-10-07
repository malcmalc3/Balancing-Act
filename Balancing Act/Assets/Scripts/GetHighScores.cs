using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetHighScores : MonoBehaviour {

    public GameObject scoresList;

    void Start ()
    {
        string high1 = ConvertToTime(PlayerPrefs.GetFloat("highScore1", 0.0f));
        string high2 = ConvertToTime(PlayerPrefs.GetFloat("highScore2", 0.0f));
        string high3 = ConvertToTime(PlayerPrefs.GetFloat("highScore3", 0.0f));
        string high4 = ConvertToTime(PlayerPrefs.GetFloat("highScore4", 0.0f));
        string high5 = ConvertToTime(PlayerPrefs.GetFloat("highScore5", 0.0f));

        string date1 = PlayerPrefs.GetString("highScoreDate1", "Date");
        string date2 = PlayerPrefs.GetString("highScoreDate2", "Date");
        string date3 = PlayerPrefs.GetString("highScoreDate3", "Date");
        string date4 = PlayerPrefs.GetString("highScoreDate4", "Date");
        string date5 = PlayerPrefs.GetString("highScoreDate5", "Date");

        string listText = string.Format("1\t" + high1 + "\t" + date1 + "\n" +
                                        "2\t" + high2 + "\t" + date2 + "\n" +
                                        "3\t" + high3 + "\t" + date3 + "\n" +
                                        "4\t" + high4 + "\t" + date4 + "\n" +
                                        "5\t" + high5 + "\t" + date5);

        scoresList.GetComponent<TextMeshProUGUI>().text = listText;
    }

    string ConvertToTime(float time)
    {
        string str = "";

        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        int fraction = (int)(time * 100) % 100;

        str = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, fraction);

        return str;
    }
}
