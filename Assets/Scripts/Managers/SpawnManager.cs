using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }
    public GameVariables GameVariables;

    [SerializeField] public int numberOfEnemiesPerWave;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private List<BaseEnemy> wave;

    void Update()
    {
        // If Number of Enemies in Wave is == 0 we up the Wave and go to the next one
        if(wave.Count == 0)
        {
            GameVariables.IncreaseWave();
            SpawnEnemies();
        }
    }

    public void SpawnWaves()
    {
        SpawnEnemies(WaveEnemyTypes.Zombie);
    }

    public void SpawnEnemies(WaveEnemyTypes type)
    {
        // Select randomly between a few types of waves
        // Enemies strenght is not related to Player Level but the number of waves
        // This way we can have XP boosters

        BaseEnemy enemy = null;
        
        switch (type)
        {
            case WaveEnemyTypes.Zombie:
                enemy = new Zombie();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }


        for (int i = 0; i < numberOfEnemiesPerWave; i++)
        {
            //SPawn the above type;enemy
            //wave.Add(enemy);
        }
    }

    public void SpawnPlayer()
    {

    }
}


public enum WaveEnemyTypes
{
    Skeleton = 0,
    SkeletonBoss = 1,
    Zombie = 2,
    ZombieBoss = 3,
    Mixed = 4,
}