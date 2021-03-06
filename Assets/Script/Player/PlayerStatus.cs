using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private UnityEvent _onKilled;
    [SerializeField] private UnityEvent _onRestore;
    public bool IsAlive { get; private set; } = true;
    public void Kill()
    {
        if(!IsAlive)
            return;
        IsAlive = false;
        _onKilled.Invoke();
        Debug.Log("Player is killed");
    }
    public void Restore()
    {
        if(IsAlive)
            return;
        
        IsAlive = true;
        _onRestore.Invoke();
        Debug.Log("Player is restored");
    }
}
