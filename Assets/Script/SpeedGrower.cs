using System;
using System.Collections;
using System.Collections.Generic;
using SpeedyFishb;
using UnityEngine;
using UnityEngine.Events;

public class SpeedGrower : MonoBehaviour
{
    [SerializeField] private float _growSpeedSpeed = 0.1f;
    [SerializeField] private float _startSpeed = 1.0f;
    
    private float _currentGlobalSpeedGrow;
    
    public float GetSpeedWithCurrentGrow(float speed)
    {
        return _currentGlobalSpeedGrow * speed;
    }
    
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(GrowSpeed());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator GrowSpeed()
    {
        int i = 1;
        while (true)
        {
            _currentGlobalSpeedGrow = 1 + _growSpeedSpeed * i++;
            Debug.Log($"Current speed grow {_currentGlobalSpeedGrow}");
            yield return new WaitForSeconds(1f);
        }
    }
}
