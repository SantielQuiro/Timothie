using UnityEngine;

public class TimeTrial : MonoBehaviour
{
    [SerializeField] private float timeLimit = 60f; // Time limit in seconds
    [SerializeField] WinCondition winCondition; // Reference to the WinCondition script
    private float timer;
    private bool WinConditionMet = false;

    public TMPro.TextMeshProUGUI timerText; // Reference to the UI text element to display the timer

    void Start()
    {
        timer = timeLimit;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (WinConditionMet)
        {
            Debug.Log("You win! Record: " + (Mathf.CeilToInt(timer) - timeLimit) + " seconds");
        }
        else if (timer <= 0)
        {
            Debug.Log("Time's up! You lose!");
        }

        timerText.text = "Time: " + Mathf.CeilToInt(timer).ToString();
    }
    public void OnWinConditionMet()
    {
        WinConditionMet = true;
    }
    private void OnEnable()
    {
        winCondition.OnWinConditionMet += OnWinConditionMet; // Subscribe to the win condition event
    }
    private void OnDisable()
    {
        winCondition.OnWinConditionMet -= OnWinConditionMet; // Unsubscribe from the win condition event
    }
}
