using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject PlayerPrefab;

    public static SpawnManager Instance { get; private set; }
    public GameVariables GameVariables;
    public int NumberOfEnemiesPerWave;
    public GameObject Player { get; private set; }

    private List<BaseEnemy> wave;

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


    void Update()
    {
        // If Number of Enemies in Wave is == 0 we up the Wave and go to the next one
        if(wave.Count == 0)
        {
            GameVariables.IncreaseWave();
            SpawnEnemies(WaveEnemyType.Zombie);
        }
    }

    public void SpawnWaves()
    {
        

    }

    public void SpawnEnemies(WaveEnemyType type)
    {
        // Select randomly between a few types of waves
        // Enemies strenght is not related to Player Level but the number of waves
        // This way we can have XP boosters

        BaseEnemy enemy = null;
        
        switch (type)
        {
            case WaveEnemyType.Zombie:
                enemy = new Zombie();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }


        for (int i = 0; i < NumberOfEnemiesPerWave; i++)
        {
            //SPawn the above type;enemy
            //wave.Add(enemy);
        }
    }

    public void SpawnPlayer()
    {
        Player = Instantiate(PlayerPrefab);
    }

    public void OnLevelUp()
    {
        NumberOfEnemiesPerWave += GameVariables.PlayerLevel * 10;
    }
}


public enum WaveEnemyType
{
    Skeleton = 0,
    SkeletonBoss = 1,
    Zombie = 2,
    ZombieBoss = 3,
    Mixed = 4,
}