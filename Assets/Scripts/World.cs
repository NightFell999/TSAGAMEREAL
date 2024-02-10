using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    
    public string worldName;
    public float difficultyModifier;
    public float encounterRate;

    public GameObject [] RandomEnemies;

    public GameObject [] SetEnemies;

    public GameObject[] currentEnemies;

    private void Start()
    {
        Debug.Log("Working");
    }

}
