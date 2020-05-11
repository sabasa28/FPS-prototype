using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TextShowed : MonoBehaviour
{
    public TextMeshProUGUI textToShow;
    GameplayManager gameplayManager;
    public int healthShown = 0;
    public int scoreShown = 0;


    public Action setGameplayUIText;

    void Start()
    {
        gameplayManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayManager>();
        textToShow = gameObject.GetComponent <TextMeshProUGUI>();
    }



    void Update()
    {
        setGameplayUIText();

        textToShow.text = "Health: " + healthShown + "\nPoints: " + scoreShown;
    }
}
