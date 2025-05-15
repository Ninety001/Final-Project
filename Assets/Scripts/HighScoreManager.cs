using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public bool isNewHighScore = false;
    public static HighScoreManager Instance;
    public bool isGameOver = false;

    public float distance = 0f;
    public float highDistance = 0f;

    public float moveSpeed = 10f;

    private bool gameOver = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        highDistance = PlayerPrefs.GetFloat("HighDistance", 0f);
        
    }

    void Update()
    {
        if (!gameOver)
        {
            distance += Time.deltaTime * moveSpeed;
            
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOver = true;

        if (distance > highDistance)
        {
            highDistance = distance;
            PlayerPrefs.SetFloat("HighDistance", highDistance);
            isNewHighScore = true;

        }
       
    }
}
