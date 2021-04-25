using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpeedGrower _speedGrower;
    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
    
    private float GrowledSpeed =>  _speedGrower.GetSpeedWithCurrentGrow(_speed);
    
    private void Start()
    {
        _speedGrower = FindObjectOfType<SpeedGrower>();
    }

    public void FixedUpdate()
    {
        transform.position += Vector3.left * (GrowledSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerStatus = other.gameObject.GetComponent<PlayerStatus>();
        if(playerStatus == null)
            return;

        playerStatus.Kill();
    }
}