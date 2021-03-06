using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureManager : MonoBehaviour
{

    public static GestureManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private Touch trackedFinger1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount>0)
        {
            trackedFinger1 = Input.GetTouch(0);
        }
    }

    private void OnDrawGizmos()
    {
        if (Input.touchCount>0)
        {
            Debug.Log("tats");
            Ray ray = Camera.main.ScreenPointToRay(trackedFinger1.position);
            Gizmos.DrawIcon(ray.GetPoint(5), "ghost");

        }
    }
}
