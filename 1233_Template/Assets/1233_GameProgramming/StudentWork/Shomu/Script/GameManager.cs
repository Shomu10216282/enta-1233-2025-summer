using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWonUI;
    private bool isGameOver = false;
    public bool isGameWon = false;
    public AudioSource WinSound;
    public AudioSource LoseSound;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GameWon()
    {
        if (isGameWon) return;

        Cursor.lockState = CursorLockMode.Confined;

        isGameWon = true;
        gameWonUI.SetActive(true);
        Time.timeScale = 0f;
        WinSound.Play();
    }

    public void GameOver()
    {
        if (isGameOver) return;

        Cursor.lockState = CursorLockMode.Confined;

        isGameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;

        LoseSound.Play();
    }

   

    public void RestartGame()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToTitle()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
