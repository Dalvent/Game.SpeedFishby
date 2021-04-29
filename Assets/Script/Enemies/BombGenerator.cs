using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using Script.Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BombPool))]
public class BombGenerator : MonoBehaviour
{
    [Min(0)][SerializeField] private float _minSpawnInterval;
    [Min(0)][SerializeField] private float _maxSpawnInterval;
    [SerializeField] private float _startSpawnPointY;
    [SerializeField] private float _endSpawnPointY;
    [Min(0)][SerializeField] private float _minBombSize;
    [Min(0)][SerializeField] private float _maxBombSize;
    [Min(0)][SerializeField] private float _minBombSpeed;
    [Min(0)][SerializeField] private float _maxBombSpeed;

    private BombPool _bombPool;

    private readonly DateTime GameStartDateTime = DateTime.Now;

    private DateTime _generateNextBombTime = DateTime.Now;

    private void Start()
    {
        _generateNextBombTime = DateTime.Now;
        _bombPool = GetComponent<BombPool>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (DateTime.Now < _generateNextBombTime) 
            return;

        GenerateBomb();
        _generateNextBombTime = GenerateTimeInterval();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private GameObject GenerateBomb()
    {
        return _bombPool.InflateBomb(
            GenerateBombLocation(),
            GenerateBombSize(),
            GenerateBombSpeed()
        ).gameObject;
    }

    private float GenerateBombSpeed()
    {
        return Random.Range(_minBombSpeed, _maxBombSpeed);
    }

    private Vector2 GenerateBombSize()
    {
        return Vector2.one * Random.Range(_minBombSize, _maxBombSize);
    }
    
    private DateTime GenerateTimeInterval()
    {
        return DateTime.Now.AddSeconds(Random.Range(_minSpawnInterval, _maxSpawnInterval));
    }

    private Vector2 GenerateBombLocation()
    {
        return new Vector2(transform.position.x, transform.position.y + Random.Range(_endSpawnPointY, _startSpawnPointY));
    }
}
