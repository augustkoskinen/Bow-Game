using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int health;

    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Highscore") == null){
        PlayerPrefs.SetInt("Highscore", 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        healthText.text = health.ToString();
        highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
    
    public void TakeDamage() {
            health--;
            if(health <= 0) {
                SceneManager.LoadScene("Game");
            }
    }
}
