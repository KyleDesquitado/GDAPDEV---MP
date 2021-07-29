using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] HandheldCameraBehavior camera;
    [SerializeField] PlayerController player;
    [SerializeField] EnemySpawner spawner;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.getCameraFlashBool())
        {
            target = camera.getVisibleTarget();
            if(target != null)
            {
                spawner.respawnEnemy(target);
                target.SetActive(false);
                camera.removeTarget(target);
            }
        }
    }
}
