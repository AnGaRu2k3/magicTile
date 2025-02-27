using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ScoreEvent scoreEvent; 
    private int score = 0;
    private int streak = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddScore(int amount, bool isPerfect)
    {
        streak = isPerfect ? streak + 1 : 1;
        score += amount * streak;
        Debug.Log("Score: " + score);

        scoreEvent.Raise(streak, isPerfect, score); 
    }
}

