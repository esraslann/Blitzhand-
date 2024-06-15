using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    private bool musicPlaying = true;
    public int healthPoint = 3;
    public int score = 0;

    [Header("UI")]
    public TMP_Text scoreText;
    public Transform[] healthSprite = new Transform[3];
    public Transform menuPanel;

    public Button pauseGameButton;
    public Button resumeGameButton;
    public Button RestartButton;
    public Button musicButton;

    public Sprite soundOn, soundOff;
    private void Start()
    {
        resumeGameButton.gameObject.SetActive(true);
        scoreText.text = "SCORE : " + score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "SCORE : " + score.ToString();
    }

    public void DecreaseHealthPoint()
    {
        CalculateHealthPoint();
    }

    public void CalculateHealthPoint()
    {
        if (healthPoint > 0)
        {
            // Son can sprite'ýný sil
            Destroy(healthSprite[healthPoint - 1].gameObject);
            healthPoint--;

            if (healthPoint == 0)
            {
                Debug.Log("Oyun bitti!"); // Tüm canlar tükendiðinde yapýlacak iþlemler
                resumeGameButton.gameObject.SetActive(false);
                Time.timeScale = 0;
                menuPanel.gameObject.SetActive(true);
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        menuPanel.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        menuPanel.gameObject.SetActive(true);
    }

    public void ToggleMusicOnOff()
    {
        musicPlaying = !musicPlaying;
        if (musicPlaying)
        {
            music.Play(0);
            musicButton.GetComponent<Image>().sprite = soundOn; 
        }
        else
        {
            music.Stop();
            musicButton.GetComponent<Image>().sprite = soundOff;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
