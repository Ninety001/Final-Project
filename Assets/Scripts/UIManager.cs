using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI coinText;
    public GameObject newHighScoreText;

    private bool shownNewHighScore = false;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateCoinText(int count)
    {
        coinText.text = $"Coins: {count}";
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