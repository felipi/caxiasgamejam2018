using RoboRyanTron.Unite2017.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMechanics : MonoBehaviour
{
    public int comboColdown;
    public GameEvent makeScoreEvent;
    public GameEvent makePerfectScoreEvent;
    public IntVariable actualScore;

    private int _combo;
    private float _comboColdown;
    private int _score;

    // Use this for initialization
    void Start()
    {
        _score = 0;
        _combo = 0;
        if (actualScore != null) actualScore.SetValue(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.makeScoreEvent.Raise();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            this.makePerfectScoreEvent.Raise();
        }

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
    }
}
