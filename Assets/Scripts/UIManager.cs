using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour  
{
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI highScoreText;
    public GameObject newHighScoreText;

    private bool showNewHighScore = false;

    void Update()
    {
        if (HighScoreManager.Instance != null)
        {
            float distance = HighScoreManager.Instance.distance;
            float highScore = HighScoreManager.Instance.highDistance;

            distanceText.text = $"Distance: {distance:F2} m";
            highScoreText.text = $"High Score: {highScore:F2} m";
        }

        if (!showNewHighScore && HighScoreManager.Instance.isNewHighScore && HighScoreManager.Instance.isGameOver)
        {
            newHighScoreText.SetActive(true);
            showNewHighScore = true;
        }
    }
}