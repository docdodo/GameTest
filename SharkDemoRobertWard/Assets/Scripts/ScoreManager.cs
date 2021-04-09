using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private float currentScore;
    private float highScore;
    [SerializeField]
    private Text poinTtext;
   
    public void IncreasePoints(float points)
    {
        currentScore += points;
        poinTtext.text = currentScore.ToString();
    }


   
}
