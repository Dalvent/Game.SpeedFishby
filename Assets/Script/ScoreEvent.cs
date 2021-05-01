using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpeedyFishb
{
    [Serializable]
    public class ScoreEvents
    {
        [SerializeField] private List<ScoreEventItem> _scoreEventItems = new List<ScoreEventItem>();

        public void OnUpdate(int currentScore)
        {
            foreach (var scoreEvent in _scoreEventItems)
            {
                scoreEvent.OnUpdate(currentScore);
            }
        }
    }
    
    [Serializable]
    public class ScoreEventItem
    {
        [SerializeField] private int _scoreToInvoke;
        [SerializeField] private UnityEvent _event;
        private bool _isExecuted = false;

        public void OnUpdate(int currentScore)
        {
            if(_isExecuted || _scoreToInvoke >= currentScore)
                return;

            _isExecuted = true;
            _event.Invoke();
            Debug.Log($"Score event on {_scoreToInvoke} invoked!");
        }
    }
}
