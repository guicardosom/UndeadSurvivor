using UnityEngine;
using UnityEngine.Events;
public class EventTriggerListener : MonoBehaviour 
{ 
    public EventTrigger gameEvent;
    public UnityEvent onEventTriggered;

    void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }

    public void OnEventTriggered()
    {
        onEventTriggered.Invoke();
    }
}