using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public TextMeshProUGUI text;
    private int score;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void changeScore(int coinValue)
    {
        score += coinValue;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (text != null)
        {
            text.text = "Score: " + score.ToString();
        }
    }
}
