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

    public int coinCount = 0;

    public void AddCoin()
    {
        coinCount++;
        UIManager.Instance.UpdateCoinText(coinCount);
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HighScoreManager.Instance.AddCoin();
            Destroy(gameObject);
        }
    }

    public void ResetGame()
    {
        distance = 0f;
        isGameOver = false;
        isNewHighScore = false;
    }

    public void ResetStats()
    {
        distance = 0;
        isGameOver = false;
        isNewHighScore = false;
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
        UIManager.Instance.ShowGameOver();


        if (distance > highDistance)
        {
            highDistance = distance;
            PlayerPrefs.SetFloat("HighDistance", highDistance);
            isNewHighScore = true;

        }
       
    }
}
