using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrementor : MonoBehaviour
{
    [SerializeField] private bool _needIncrement = true;
    public int Score { get; private set; }
    // Update is called once per frame

    private void Start()
    {
        _playerStatus = FindObjectOfType<PlayerStatus>();
    }

    void Update()
    {
        if (_playerStatus.IsAlive) 
            Score += 1;
    }
    
    public void OnKilled()
    {
        _canvas.gameObject.SetActive(true);
    }
    
    public void OnRestore()
    {
        _canvas.gameObject.SetActive(false);
    }
}
