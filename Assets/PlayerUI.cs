using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    private ScoreIncrementor _scoreIncrementor;
    
    // Update is called once per frame
    private void Start()
    {
        _scoreIncrementor = FindObjectOfType<ScoreIncrementor>();
    }

    void Update()
    {
        _text.text = $"Score: {_scoreIncrementor.Score}";
    }
}
