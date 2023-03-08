using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

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

    void Start()
    {
        ChangeState(GameState.GenerateMap);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;

        switch (newState)
        {
            case GameState.GenerateMap:
                MapManager.Instance.GenerateMap();
                break;
            case GameState.SpawnPlayer:
                SpawnManager.Instance.SpawnPlayer();
                break;
            case GameState.SpawnWaves:
                SpawnManager.Instance.SpawnWaves();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState
{
    GenerateMap = 0,
    SpawnPlayer = 1,
    SpawnWaves = 2,
}