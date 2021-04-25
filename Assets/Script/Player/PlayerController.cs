using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStatus _playerController;
    [Min(0)][SerializeField] private float _speed;
    
    void Start()
    {
        _playerController = GetComponent<PlayerStatus>();
    }

    void FixedUpdate()
    {
        if(!_playerController.IsAlive)
            return;
        
        var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.fixedDeltaTime);
    }
}
