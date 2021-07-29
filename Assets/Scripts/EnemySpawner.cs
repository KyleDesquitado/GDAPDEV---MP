using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemySpawnList;
    [SerializeField] GameObject enemyObj;
    [SerializeField] GameObject player;
    [SerializeField] HandheldCameraBehavior targetHolder;
    // Start is called before the first frame update
    void Start()
    {
        while(enemySpawnList.Count != 0)
        {
            GameObject enemySpawn = GameObject.Instantiate(enemyObj, enemySpawnList[0].transform.position, Quaternion.identity, null);
            enemySpawn.transform.LookAt(player.transform);
            targetHolder.addTarget(enemySpawn);
            enemySpawnList.RemoveAt(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
