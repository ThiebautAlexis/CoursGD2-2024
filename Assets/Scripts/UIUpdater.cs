using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIUpdater : MonoBehaviour
{
    public TextMeshProUGUI TextMesh;
    private int score = 0; 
    public void AddScore()
    {
        score += 100; 
        TextMesh.text = "Score : " + score.ToString();
    }

    public void AddScore(int _score)
    {
        score += _score;
        TextMesh.text = "Score : " + score.ToString();

    }
}
