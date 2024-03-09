using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingText : MonoBehaviour
{
    GameObject movingText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movingText.transform.position += new Vector3(0, 0.1f, 0) * Time.deltaTime;
    }

    void CreateText(GameObject location, string text)
    {





    }
}
