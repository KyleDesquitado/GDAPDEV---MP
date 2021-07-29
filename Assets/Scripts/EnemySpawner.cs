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
        //while(enemySpawnList.Count != 0)
        //{
        //    GameObject enemySpawn = GameObject.Instantiate(enemyObj, enemySpawnList[0].transform.position, Quaternion.identity, null);
        //    enemySpawn.transform.LookAt(player.transform);
        //    targetHolder.addTarget(enemySpawn);
        //    enemySpawnList.RemoveAt(0);
        //}

        for(int i = 0; i < enemySpawnList.Count; i++)
        {
            GameObject enemySpawn = GameObject.Instantiate(enemyObj, enemySpawnList[i].transform.position, Quaternion.identity, null);
            enemySpawn.transform.LookAt(player.transform);
            enemySpawn.GetComponent<EnemyBehavior>().setTarget(player);
            targetHolder.addTarget(enemySpawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> getSpawnList()
    {
        return enemySpawnList;
    }
    
    public void respawnEnemy(GameObject deadEnemy)
    {
        for(int i = 0; i < enemySpawnList.Count; i++)
        {
            if(deadEnemy.transform.position == enemySpawnList[i].transform.position)
            {
                float delayTime = Random.Range(7f, 15f);
                StartCoroutine(reviveDelay(delayTime, i));
            }
        }

    }

    private IEnumerator reviveDelay(float waitTime, int index)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject enemySpawn = GameObject.Instantiate(enemyObj, enemySpawnList[index].transform.position, Quaternion.identity, null);
        enemySpawn.transform.LookAt(player.transform);
        enemySpawn.GetComponent<EnemyBehavior>().setTarget(player);
        targetHolder.addTarget(enemySpawn);
    }
}
