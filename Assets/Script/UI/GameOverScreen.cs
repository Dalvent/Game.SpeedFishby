using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    
    public void OnKilled()
    {
        _canvas.gameObject.SetActive(true);
    }
    
    public void OnRestore()
    {
        _canvas.gameObject.SetActive(false);
    }
}
