using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public ScoreEvent scoreEvent;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Slider slider;
    [SerializeField] private List<GameObject> stars;
    [SerializeField] private TMP_Text great, perfect, streakText;
    [SerializeField] private Image backGround;
    [SerializeField] int starCnt = 0;

    private void OnEnable()
    {
        scoreEvent.OnScoreChanged += UpdateScoreUI;
        scoreEvent.OnStreakChanged += UpdateStreakPopUp;

    }

    private void OnDisable()
    {
        scoreEvent.OnScoreChanged -= UpdateScoreUI;
        scoreEvent.OnStreakChanged -= UpdateStreakPopUp;
    }

    private void UpdateScoreUI(int newScore)
    {
        scoreText.text = newScore.ToString();
        // slider
        slider.value = newScore;
        if (newScore >= 10 && starCnt < 1) { stars[0].GetComponent<Animator>().SetTrigger("achieved"); starCnt++; }
        if (newScore >= 15 && starCnt < 2) { stars[1].GetComponent<Animator>().SetTrigger("achieved"); starCnt++; }
        if (newScore >= 20 && starCnt < 3) { stars[2].GetComponent<Animator>().SetTrigger("achieved"); starCnt++; }


    }
    private void UpdateStreakPopUp(int streak, bool isPerfect)
    {
        great.gameObject.SetActive(false);
        perfect.gameObject.SetActive(false);
        streakText.gameObject.SetActive(false);
        backGround.gameObject.SetActive(false);
        if (isPerfect)
        {
            perfect.gameObject.SetActive(true);
        }
        else great.gameObject.SetActive(true);


        streakText.gameObject.SetActive(true);
        streakText.text = "x " + streak;
        backGround.gameObject.SetActive(true);


        
    }
}
