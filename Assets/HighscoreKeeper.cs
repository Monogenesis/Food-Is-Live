using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreKeeper : MonoBehaviour
{

    public static float Food_Highscore;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
