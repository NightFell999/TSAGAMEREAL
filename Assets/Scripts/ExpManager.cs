using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ExpManager : MonoBehaviour
{

    [Header("Experience")]
    [SerializeField] AnimationCurve experienceCurve;

    int currentlevel, totalExperience;
    int previousLevelExperience, nextLevelExperience;

    [Header("interface")]
    [SerializeField] TextMeshProUGUI leveltext;
    [SerializeField] TextMeshProUGUI experiencetext;
    [SerializeField] Image experienceFill;
    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P)) 
        {
            addexperience(5000);
        }
    }

    public void addexperience(int amount)
    {
        totalExperience += amount;
        CheckForLevelUp();
        Updateinterface();
            
     }

    void CheckForLevelUp()
    {
        if(totalExperience >= nextLevelExperience)
        {
            currentlevel++;
            UpdateLevel();
        }
    }

    private void UpdateLevel()
    {
        previousLevelExperience = (int)experienceCurve.Evaluate(currentlevel);
        nextLevelExperience = (int)experienceCurve.Evaluate(currentlevel + 1);
        Updateinterface();
        UpdateLevel();
    }


    void Updateinterface()
    {
        int start = totalExperience - previousLevelExperience;
        int end = nextLevelExperience - previousLevelExperience;

        leveltext.text = currentlevel.ToString();
        experiencetext.text = start + " Exp /" + end + " Exp";
        experienceFill.fillAmount = (float)start / (float)end;
    }



}


