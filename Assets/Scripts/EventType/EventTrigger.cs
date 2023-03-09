using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Trigger Event")]
public class EventTrigger : ScriptableObject
{
    private List<EventTriggerListener> listeners = new List<EventTriggerListener>();

    public void TriggerEvent()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered();
        }
    }

    public void AddListener(EventTriggerListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(EventTriggerListener listener)
    {
        listeners.Remove(listener);
    }
}