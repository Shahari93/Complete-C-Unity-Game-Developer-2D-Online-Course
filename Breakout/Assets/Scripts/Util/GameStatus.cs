using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 2)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlock = 10;

    [SerializeField] private int currentScore;
    [SerializeField] private TextMeshProUGUI scoreText;

    public static GameStatus gameStatus { get; private set; }

    private void Awake()
    {
        if (gameStatus != null)
        {
            gameObject.SetActive(false); // Because of script execution order
            Destroy(gameObject);
            return;
        }
            gameStatus = this;
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    private void Update()
    {
        // We can alter the game speed by using the game speed slider, or by a power up if we want
        Time.timeScale = gameSpeed;
    }

    // adding the points to the score handler
    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }

    public void RestartScoreOnNextSession()
    {
        Destroy(gameObject);
    }
}