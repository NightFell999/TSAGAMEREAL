using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class ExpManager : MonoBehaviour
{

    [Header("Experience")]
    [SerializeField] AnimationCurve experienceCurve;
    public float MaxLevel;
    public float MaxXp;

    public float currentlevel = 0, totalExperience = 0;
    int previousLevelExperience, nextLevelExperience;

    [Header("interface")]
    [SerializeField] TextMeshProUGUI leveltext;
    [SerializeField] TextMeshProUGUI experiencetext;
    [SerializeField] Image experienceFill;
    
    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateLevel();

        MaxXp = experienceCurve.keys[experienceCurve.keys.Length - 1].value;
        MaxLevel = experienceCurve.keys[experienceCurve.keys.Length - 1].time;
    }

    // Update is called once per frame
    void Update()
    {

        
        
        if (currentlevel >= MaxLevel)
        {
            Updateinterface();
            currentlevel = MaxLevel;
            experiencetext.text = "MAX Level";
            experienceFill.fillAmount = 1;
        }
        if (Input.GetKeyUp(KeyCode.P)) 
        {
            addexperience(500);
        }
    }

    public void addexperience(int amount)
    {
        if (currentlevel >= MaxLevel)
        {
            return;
        }
        if (totalExperience + amount <= MaxXp)
        {
            totalExperience += amount;
        }
        else if (totalExperience + amount >= MaxXp)
                {
            totalExperience = MaxXp;
            experienceFill.fillAmount = 1;
        }



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
        CheckForLevelUp();
    }


    void Updateinterface()
    {
        float start = totalExperience - previousLevelExperience;
        float end = nextLevelExperience - previousLevelExperience;

        leveltext.text = currentlevel.ToString();
        experiencetext.text = start + " Exp /" + end + " Exp";
        experienceFill.fillAmount = (float)start / (float)end;
    }



}


