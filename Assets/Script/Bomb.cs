using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
    
    private void Start()
    {
        Debug.Log("Start");
    }

    public void FixedUpdate()
    {
        transform.position += Vector3.left * (_speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerStatus = other.gameObject.GetComponent<PlayerStatus>();
        if(playerStatus == null)
            return;

        playerStatus.Kill();
    }
}