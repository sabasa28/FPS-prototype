using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextShowed : MonoBehaviour
{
    public TextMeshProUGUI textToShow;
    Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        textToShow = gameObject.GetComponent <TextMeshProUGUI>();
    }

    void Update()
    {
        textToShow.text = "Health: " + player.hp + "\nPoints: " + player.points;
    }
}
