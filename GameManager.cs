using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Timer Settings")]
    public float gameDuration = 60f; // Total time in seconds
    private float timer;
    private bool gameRunning = false;

    [Header("Score Settings")]
    private int score = 0;
    public int Score
    {
        get => score;
        private set => score = Mathf.Max(0, value); // Clamp to minimum zero
    }

    [Header("UI Elements")]
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public GameObject endScorePanel;
    public TMP_Text finalScoreText;
    public TMP_Text finalTimeText;

    private float elapsedTime = 0f;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        ResetGame();
    }

    void Update()
    {
        if (!gameRunning) return;

        timer -= Time.deltaTime;
        elapsedTime += Time.deltaTime;

        if (timer < 0)
        {
            timer = 0;
            EndGame();
        }

        UpdateTimerUI();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }


    public void StartGame()
    {
        ResetGame();
        gameRunning = true;
    }

    public void StopGame()
    {
        gameRunning = false;
        ShowEndScore();
    }

    private void EndGame()
    {
        gameRunning = false;
        ShowEndScore();
    }

    private void ResetGame()
    {
        timer = gameDuration;
        elapsedTime = 0;
        Score = 0;
        UpdateTimerUI();
        UpdateScoreUI();
        endScorePanel.SetActive(false);
    }

    public void AddScore(int amount)
    {
        Score += amount;
        UpdateScoreUI();
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void UpdateScoreUI()
    {
        scoreText.text = $"Score: {Score}";
    }

    private void ShowEndScore()
    {
        endScorePanel.SetActive(true);
        finalScoreText.text = $"Final Score: {Score}";
        finalTimeText.text = $"Time: {elapsedTime:0.00}s";
    }
}
