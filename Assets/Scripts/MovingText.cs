using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovingText : MonoBehaviour
{
    public MeshRenderer meshrender;
    public TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponentInChildren<TextMeshPro>();
        meshrender = gameObject.GetComponentInChildren<MeshRenderer>();
        meshrender.sortingLayerName = "NotBackground";
    }

    // Update is called once per frame



    void Update()
    {
        
        gameObject.transform.position += new Vector3(0, 0.0025f, 0);
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 0.0025f);

        if(text.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }

    void CreateText(GameObject location, string text)
    {


        


    }
}
