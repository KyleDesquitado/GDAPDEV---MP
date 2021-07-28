using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] FlashImage flashImage = null;
    [SerializeField] Color newColor = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flashImage.StartFlash(0.25f, 0.8f, newColor);
        }

        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            flashImage.StartFlash(0.25f, 0.8f, newColor);
        }
    }
}
