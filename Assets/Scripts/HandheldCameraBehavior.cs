using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandheldCameraBehavior : MonoBehaviour
{
    [SerializeField] List<GameObject> targets;
    Camera cam;
    private bool canSeeTarget;
    // Start is called before the first frame update

    public static class RendererExtensions
    {
        
    }
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        canSeeTarget = false;
        if(canSeeTarget)
        {
            Debug.Log("can see target");
        }
    }

    private bool checkIfVisible(Renderer renderer, Camera camera)
    {

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

    public GameObject getVisibleTarget()
    {
        for(int i = 0; i < targets.Count; i++)
        {
            canSeeTarget = checkIfVisible(targets[i].GetComponent<Renderer>(), cam);
            if (canSeeTarget)
            {
                return targets[i];
            }
        }
        

        return null;
    }

    public void addTarget(GameObject newTarget)
    {
        targets.Add(newTarget);
    }

    public void removeTarget(GameObject destroyedTarget)
    {
        targets.Remove(destroyedTarget);
    }
}
