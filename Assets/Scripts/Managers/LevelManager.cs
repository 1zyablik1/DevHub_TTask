using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level level;
    private static Level currentLevel;

    private static bool isLevelSucceed = false;

    private void Start()
    {
        LoadLevel();
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscibe();
    }

    private void Subscribe()
    {
        Events.OnGameReset += GameReset;
        Events.OnFinishedLevel += FinishedLevel;
        Events.OnObstacleCollision += ObstacleCollision;
    }

    private void Unsubscibe()
    {
        Events.OnGameReset -= GameReset;
        Events.OnFinishedLevel -= FinishedLevel;
        Events.OnObstacleCollision -= ObstacleCollision;
    }

    private void GameReset()
    {
        DeleteLevel();
        LoadLevel();

        isLevelSucceed = false;
    }

    private void LoadLevel()
    {
        currentLevel = Instantiate(level);
    }

    private void DeleteLevel()
    {
        Destroy(currentLevel.gameObject);
    }

    public static float GetLevelProgress()
    {
        return Player.GetZPosition() / currentLevel.endPoint.position.z;
    }

    private void FinishedLevel()
    {
        isLevelSucceed = true;
        GlobalStateMachine.SetState<Finish>();
    }

    private void ObstacleCollision()
    {
        isLevelSucceed = false;
        GlobalStateMachine.SetState<Finish>();
    }

    public static bool IsLevelSucceed()
    {
        return isLevelSucceed;
    }
}
