using UnityEngine.SceneManagement;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField]private Score scoreEngine;
    [SerializeField] private TMP_Text scoreText;
    public static bool GameIsRun = false;
    public static bool GameIsPaused = false;
    public static bool isAlive = true;
    public static bool IsGameOver = false;

    public GameObject PauseMenuObjectUI;
    public GameObject PauseMenuButtonUI;
    public GameObject MainMenuObjectUI;
    public GameObject ScoreObjectUI;
    public GameObject HealthObjectUI;
    public GameObject DeathScreenObjectUI;
    public GameObject DeathPrefab;

    public LifeManager LifeManager;

    public TMP_Text score;

    void Update()
    {
        scoreText.text = scoreEngine.CurrentScore().ToString();

        if (Input.GetKeyDown(KeyCode.Escape) && GameIsRun)
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }

        if (GameIsRun && (LifeManager.IsAlive == false))
        {
            GameObject g = new GameObject();
            g.name = "Info Passer";
            DontDestroyOnLoad(g);

            DeathPrefab.SetActive(true);
            ScoreObjectUI.SetActive(false);
            HealthObjectUI.SetActive(false);
            GameObject.Find("Main Camera").transform.Rotate(new Vector3(0, 0, 0));
            DeathScreenObjectUI.SetActive(true);
            IsGameOver = true;
        }
    }

    public void RunGame()
    {
        scoreEngine.Reset();
        scoreEngine.Run = true;

        MainMenuObjectUI.SetActive(false);
        PauseMenuButtonUI.SetActive(true);
        HealthObjectUI.SetActive(true);
        ScoreObjectUI.SetActive(true);
        GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -4);
        GameIsRun = true;
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void OpenMenuPause()
    {
        if (GameIsPaused)
            Resume();
        else
            Pause();
    }

    public void Resume()
    {
        PauseMenuObjectUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameIsRun = true;
    }

    void Pause()
    {
        PauseMenuObjectUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameIsRun = true;
    }

    public void reload()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void QuitGame()
    {
        GameIsRun = false;
        Application.Quit();
    }
}
