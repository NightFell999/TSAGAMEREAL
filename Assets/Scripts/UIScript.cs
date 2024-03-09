using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    public bool turnOffUI;
    public Canvas UICanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(turnOffUI == true) {
            UICanvas.enabled = false;
        }
        else
        {
            UICanvas.enabled = true;
        }
    }
}
