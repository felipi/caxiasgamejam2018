using RoboRyanTron.Unite2017.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMechanics : MonoBehaviour
{
    const string HIGH_SCORE_KEY = "highscore";

    public int comboColdown;
    public IntVariable actualScore;
    public IntVariable highScore;

    private int _combo;
    private float _comboColdown;
    private int _score;

    // Use this for initialization
    void Start()
    {
        _score = 0;
        _combo = 0;
        if (actualScore != null) actualScore.SetValue(0);

        if (highScore)
        {
            highScore.SetValue(PlayerPrefs.GetInt(HIGH_SCORE_KEY));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_comboColdown <= 0)
        {
            clearCombo();
        }
        else
        {
            _comboColdown -= Time.deltaTime;
        }
    }

    public void MakeScore()
    {
        clearCombo();
        saveScore();
    }

    public void MakePerfectScore()
    {
        _combo++;
        _comboColdown = this.comboColdown;
        this.saveScore();
        for (int i = 0; i < _combo; i++) this.saveScore();
    }

    private void clearCombo()
    {
        _comboColdown = 0;
        _combo = 0;
    }

    private void saveScore()
    {
        _score += 1;

        if (actualScore != null)
            actualScore.SetValue(_score);

        if (highScore && _score > highScore.Value)
        {
            highScore.SetValue(_score);
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, _score);
        }
    }
}
