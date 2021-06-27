using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawn = 1f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Transform> GetWaypoints()
    {
      var waveWaypoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
          waveWaypoints.Add(child);
        }
return waveWaypoints;
    }
public GameObject GetPathPrefab()
{
    return pathPrefab;
}

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawn;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int GetNumberEnemies()
    {
        return numberEnemies;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
