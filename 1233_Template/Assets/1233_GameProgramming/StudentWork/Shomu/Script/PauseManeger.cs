using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject settingUI;

    private bool isPaused = false;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        if (gameManager != null && (gameManager.isGameWon || gameManager.isGameOver))
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (settingUI.activeSelf)
            {
                return;
            }
            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Resume();
            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined;
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
    }

    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false);
        settingUI.SetActive(true);
    }

    public void BackToPauseMenu()
    {
        settingUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void QuitToTitle()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }
}


