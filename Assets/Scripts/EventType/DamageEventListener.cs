using UnityEngine;
using UnityEngine.Events;
public class DamageEventListener : MonoBehaviour
{
    public DamageEvent gameEvent;
    public UnityEvent<Damage> onEventTriggered;

    void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }

    public void OnEventTriggered(Damage dmg)
    {
        onEventTriggered.Invoke(dmg);
    }
}