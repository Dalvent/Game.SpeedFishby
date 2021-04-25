using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrementor : MonoBehaviour
{
    [SerializeField] private int _scoreInSecond = 24;
    private bool _needIncrement = true;
    public int Score { get; private set; }
    // Update is called once per frame
    
    void FixedUpdate()
    {
        Score += _scoreInSecond;
    }
    
    public void OnPlayerKilled()
    {
        _needIncrement = false;
    }
    
    public void OnPlayerRestore()
    {
        _needIncrement = true;
    }
}
