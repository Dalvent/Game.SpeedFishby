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
        transform.position = NormalizeByCamera(Vector3.MoveTowards(transform.position, target, _speed * Time.fixedDeltaTime));
    }

    Vector3 NormalizeByCamera(Vector3 vector)
    {
        var verticalSize = (float)(Camera.main.orthographicSize * 2.0) / 2;
        var horizontalSize = (float)(verticalSize * Screen.width / Screen.height);
        return new Vector3(
            ValueInRange(vector.x, -horizontalSize, horizontalSize),
            ValueInRange(vector.y, -verticalSize, verticalSize)
         );
    }

    float ValueInRange(float value, float min, float max)
    {
        return Math.Max(Math.Min(value, max), min);
    }
}
