
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.UIElements;

public class Score : MonoBehaviour
{
    private float score;
    private bool run = true;

    public bool Run
    {
        get { return run; }
        set { run = value; }
    }

    public int HighScore
    {
        get { return PlayerPrefs.GetInt("HighScore", 0); }
        set { PlayerPrefs.SetInt("HighScore", value); }
    }

    void Update()
    {
        if (run) { score += Time.deltaTime; }
    }

    public int CurrentScore()
    {
        return (int)score;
    }

    public void Reset()
    {
        score = 0.0f;
    }
}
