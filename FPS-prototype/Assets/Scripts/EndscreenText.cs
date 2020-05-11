using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndscreenText : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Get().gameState)
        {
            case GameManager.GameState.won:
                textMeshPro.text = "YOU WON!";
                break;
            case GameManager.GameState.lost:
                textMeshPro.text = "Game over...";
                break;
        }
    }
}
