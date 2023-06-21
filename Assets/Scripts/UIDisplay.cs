using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health healthDisplay;


    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper =  FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthSlider.maxValue = healthDisplay.GetHealth();
    }


    void Update()
    {
        healthSlider.value = healthDisplay.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("00000000");
    }




}
