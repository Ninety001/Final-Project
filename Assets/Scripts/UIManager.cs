using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public Toggle musicToggle;

    private bool shownNewHighScore = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ShowMainMenu();
        musicToggle.onValueChanged.AddListener(ToggleMusic);
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        historyPanel.SetActive(false);
        optionPanel.SetActive(false);
    }

    public void ShowHistory() { mainMenuPanel.SetActive(false); historyPanel.SetActive(true); }

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