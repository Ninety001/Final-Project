using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI coinText;
    public GameObject newHighScoreText;

    public GameObject mainMenuPanel;
    public GameObject gameOverPanel;
    public GameObject historyPanel;
    public GameObject optionPanel;
    public GameObject gamePanel;
    public TextMeshProUGUI historyText;


    public Toggle musicToggle;
    public static bool isRestarting = false;

    private bool shownNewHighScore = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (isRestarting)
        {
           
            gamePanel.SetActive(true);
            mainMenuPanel.SetActive(false);
            Time.timeScale = 1f;

            isRestarting = false;
        }
        else
        {
           
            ShowMainMenu();
        }

        musicToggle.onValueChanged.AddListener(ToggleMusic);
        distanceText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameOverPanel.SetActive(false);

        distanceText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);

        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        player.ResetPlayer();
        player.isGameStarted = true;

        Time.timeScale = 1f;
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        historyPanel.SetActive(false);
        optionPanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ShowHistory() 
    {
        mainMenuPanel.SetActive(false);
        historyPanel.SetActive(true);

        List<PlayHistoryManager.PlayRecord> history = PlayHistoryManager.Instance.GetHistory();

        string result = "Play History:\n";
        for (int i = 0; i < history.Count; i++)
        {
            result += $"#{i + 1} - Distance: {history[i].distance:F2} m, Coins: {history[i].coins}\n";
        }

        historyText.text = result;
    }

    public void ShowOption()
    {
        mainMenuPanel.SetActive(false);
        optionPanel.SetActive(true);
        musicToggle.isOn = AudioListener.volume > 0;
    }

    public void ToggleMusic(bool isOn)
    {
        AudioListener.volume = isOn ? 1 : 0;
    }

    public void UpdateCoinText(int count)
    {
        coinText.text = $"Coins: {count}";
    }

    public void ReturnToMenu() => ShowMainMenu();

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void RestartGame()
    {
        isRestarting = true;
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    



    void Update()
    {
        if (HighScoreManager.Instance != null)
        {
            float distance = HighScoreManager.Instance.distance;
            float highScore = HighScoreManager.Instance.highDistance;

            distanceText.text = $"Distance: {distance:F2} m";
            highScoreText.text = $"High Score: {highScore:F2} m";

            if (!shownNewHighScore && HighScoreManager.Instance.isNewHighScore && HighScoreManager.Instance.isGameOver)
            {
                newHighScoreText.SetActive(true);
                shownNewHighScore = true;
            }
        }
    }
}