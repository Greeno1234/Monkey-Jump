using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatsScript : MonoBehaviour
{

    public Text highscoreText;
    public Text highscoreHardText;
    public Text totalScoreText;
    public Text totalJumpsText;
    

    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
        highscoreHardText.text = "Hard Highscore: " + PlayerPrefs.GetInt("HighscoreHard");
        totalScoreText.text = "Total Score: " + PlayerPrefs.GetInt("Total Score");
        totalJumpsText.text = "Total Jumps: " + PlayerPrefs.GetInt("Total Jumps");
    }

    // Update is called once per frame
    void Update()
    {

    }

}
