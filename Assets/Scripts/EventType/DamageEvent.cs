using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Damage Event")]
public class DamageEvent : ScriptableObject
{
    private List<DamageEventListener> listeners = new List<DamageEventListener>();

    public void TriggerEvent(Damage value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered(value);
        }
    }

    public void AddListener(DamageEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(DamageEventListener listener)
    {
        listeners.Remove(listener);
    }
}