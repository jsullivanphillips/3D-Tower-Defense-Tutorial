using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    public TMP_Text moneyLabel;
    public GameObject notEnoughMoneyLabel;

    public GameObject levelCompleteScreen;
    public GameObject levelFailedScreen;

    public GameObject towerButtons;

    public GameObject pauseScreen;
    
    public void UpdateMoneyLabel()
    {
        moneyLabel.text = "Money " + MoneyManager.instance.currentMoney;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if(pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void LevelSelect()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Level Select");
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Main Menu");
    }

    public void TryAgain()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(LevelManager.instance.nextLevel);
    }

}
