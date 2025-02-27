using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/Score Event")]
public class ScoreEvent : ScriptableObject
{
    public UnityAction<int> OnScoreChanged;
    public UnityAction<int, bool> OnStreakChanged;

    public void Raise(int streak, bool isPerfect, int newScore)
    {
        if (OnScoreChanged != null)
            OnScoreChanged.Invoke(newScore);
        if (OnStreakChanged != null)
            OnStreakChanged.Invoke(streak, isPerfect);
    }
}
