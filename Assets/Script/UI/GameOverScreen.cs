using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    private const string HIGHTSCORE_KEY = "HIGHTSCORE_KEY";
    private Canvas _canvas;
    [SerializeField] private Text _hightscoreText;
    [SerializeField] private int _menuSceneIndex;

    private ScoreIncrementor _scoreIncrementor;

    private float _highscore;
    
    void Start()
    {
        _scoreIncrementor = FindObjectOfType<ScoreIncrementor>();
        _canvas = GetComponent<Canvas>();
        _canvas.gameObject.SetActive(false);
    }

    public void OnKilled()
    {
        _canvas.gameObject.SetActive(true);
        _hightscoreText.text = $"Your best score: {SaveAndGetHightscore(_scoreIncrementor.Score).ToString()}";
    }

    private int SaveAndGetHightscore(int currentGameScore)
    {
        var currentScore = _scoreIncrementor.Score;
        var currentHighscore = PlayerPrefs.GetInt(HIGHTSCORE_KEY);
        if (currentScore > currentHighscore)
        {
            PlayerPrefs.SetInt (HIGHTSCORE_KEY, currentScore);
            return currentScore;
        }
        return currentHighscore;
    }

    public void OnRestartClick()
    {
        var scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene(_menuSceneIndex);
    }
    
    public void OnRestore()
    {
        _canvas.gameObject.SetActive(false);
    }
}
