using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandheldCameraBehavior : MonoBehaviour
{
    [SerializeField] GameObject target;
    Camera cam;
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
        bool canSeeTarget = checkIfVisible(target.GetComponent<Renderer>(), cam);
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

}
