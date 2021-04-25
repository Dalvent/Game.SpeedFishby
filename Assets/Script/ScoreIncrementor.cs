using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrementor : MonoBehaviour
{
    [SerializeField] private float _scoreInSecond = 24;
    private bool _needIncrement = true;
    private SpeedGrower _speedGrower;

    public int Score { get; private set; }
    // Update is called once per frame
    
    private void Start()
    {
        _speedGrower = FindObjectOfType<SpeedGrower>();
    }
    
    void FixedUpdate()
    {
        if(_needIncrement)
            Score += (int)_speedGrower.GetSpeedWithCurrentGrow(_scoreInSecond);
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
