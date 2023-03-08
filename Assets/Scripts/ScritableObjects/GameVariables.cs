using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameVariables : ScriptableObject
{
    // These are public and have many interactions with other components
    public int PlayerLevel { get; private set; }
    public int WaveNumber { get; private set; }

    public UnityEvent onIncreaveLevelTriggered;
    public UnityEvent onIncreaseWaveTriggered;

    public void IncreaveLevel()
    {
        PlayerLevel++;
        onIncreaveLevelTriggered.Invoke();
    }

    public void IncreaseWave() 
    { 
        WaveNumber++; 
        onIncreaseWaveTriggered.Invoke(); 
    }

    public void ResetVariables()
    {
        PlayerLevel = 0;
        WaveNumber = 0;
    }
}
