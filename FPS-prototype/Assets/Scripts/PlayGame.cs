using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void ToGameplayScene()
    {
        SceneManager.LoadScene(1);
    }
}
