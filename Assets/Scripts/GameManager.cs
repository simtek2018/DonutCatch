using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    int score = 0;
    public static GameManager gm;
    public Text scoreText;
    private int lives = 3;
    [SerializeField] GameObject livesPanel;
    [SerializeField] GameObject gameOverPanel;
    

    private void Awake() {
        if (gm == null) {
            gm = this;
        }
    }

    public void incrementScore() {
        if (!gameOver) {
            score++;
            scoreText.text = score.ToString();
        }
    } 

    public void decreaseLives() {
        if (lives > 0) {
            lives--;
            livesPanel.transform.GetChild(lives).gameObject.SetActive(false);
            print("lives = " + lives);
        }
        if (lives <= 0 ) {
            EndGame();
            
        }
    }

    private void EndGame() {
        print("End Game!");
        gameOver = true;
        PastrySpawner.pastrySpawner.StopSpawning();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene("MenuScene");
    }
}
