using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroyOnLocation : MonoBehaviour
{
    [SerializeField] private float _xPositionWhereDestroy;
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= _xPositionWhereDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
