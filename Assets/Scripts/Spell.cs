using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class Spell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Canvas FightUICanvas;
    public TextMeshProUGUI buttonGUI;
    public TextMeshProUGUI description;
    public Button button;
    public Player player;
    public bool isHovering = false;
    public Sprite spellSprite;
    public GameObject fightUI;
    public GameObject enemyUI;

    //Spell Stuff
    public string spellName;
    public string spellDescription;
    public int spellDMG;
    public bool singleTarget;
    public int spellDifficulty; //1- Easy 2- Medium 3-Hard 4-Impossible
    public GameObject spellBlockContainer;
    public int spellCount;
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        fightUI = GameObject.Find("FightUI");
        player = GameObject.Find("Player").GetComponent<Player>();

        FightUICanvas = fightUI.GetComponentInChildren<Canvas>();
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }

    // Update is called once per frame
    void Update()
    {
        fightUI = GameObject.Find("FightUI");
        if (gameObject.name == "EmptySpell")
        {
            spellName = player.spells[0].GetComponent<Spell>().spellName;
            buttonGUI.text = spellName;
            spellDMG = player.spells[0].GetComponent<Spell>().spellDMG;
            singleTarget = player.spells[0].GetComponent<Spell>().singleTarget;
            spellDescription = player.spells[0].GetComponent<Spell>().spellDescription;
            spellDifficulty = player.spells[0].GetComponent<Spell>().spellDifficulty;
            spellBlockContainer = player.spells[0].GetComponent<Spell>().spellBlockContainer;
            spellCount = player.spells[0].GetComponent<Spell>().spellCount;
        }

        if (gameObject.name == "EmptySpell2")
        {
            spellName = player.spells[1].GetComponent<Spell>().spellName;
            buttonGUI.text = spellName;
            spellDMG = player.spells[1].GetComponent<Spell>().spellDMG;
            singleTarget = player.spells[1].GetComponent<Spell>().singleTarget;
            spellDescription = player.spells[1].GetComponent<Spell>().spellDescription;
            spellDifficulty = player.spells[1].GetComponent<Spell>().spellDifficulty;
            spellBlockContainer = player.spells[1].GetComponent<Spell>().spellBlockContainer;
            spellCount = player.spells[1].GetComponent<Spell>().spellCount;
        }

        if (gameObject.name == "EmptySpell3")
        {
            spellName = player.spells[2].GetComponent<Spell>().spellName;
            buttonGUI.text = spellName;
            spellDMG = player.spells[2].GetComponent<Spell>().spellDMG;
            singleTarget = player.spells[2].GetComponent<Spell>().singleTarget;
            spellDescription = player.spells[2].GetComponent<Spell>().spellDescription;
            spellDifficulty = player.spells[2].GetComponent<Spell>().spellDifficulty;
            spellBlockContainer = player.spells[2].GetComponent<Spell>().spellBlockContainer;
            spellCount = player.spells[2].GetComponent<Spell>().spellCount;
        }

        if (gameObject.name == "EmptySpell4")
        {
            spellName = player.spells[3].GetComponent<Spell>().spellName;
            buttonGUI.text = spellName;
            spellDMG = player.spells[3].GetComponent<Spell>().spellDMG;
            singleTarget = player.spells[3].GetComponent<Spell>().singleTarget;
            spellDescription = player.spells[3].GetComponent<Spell>().spellDescription;
            spellDifficulty = player.spells[3].GetComponent<Spell>().spellDifficulty;
            spellBlockContainer = player.spells[3].GetComponent<Spell>().spellBlockContainer;
            spellCount = player.spells[3].GetComponent<Spell>().spellCount;
        }



    }

    public void CastSpell(GameObject summonPosition)
    {
        fightUI = GameObject.Find("FightUI");
        enemyUI = GameObject.Find("EnemyUI");
        player = GameObject.Find("Player").GetComponent<Player>();

        FightUICanvas = fightUI.GetComponentInChildren<Canvas>();
        if(FightUICanvas.enabled == true || enemyUI.activeSelf == true)
        {
            Debug.Log("FIREBALL");
            FightUICanvas.enabled = false;


            Fight fight = player.GetComponent<Fight>();

            fight.currentSpell = gameObject.GetComponent<Spell>();



            player.spellCountCURRENT = 0;
            player.spellCountMAX = spellCount;
            player.hits = 0;





            Instantiate(spellBlockContainer, summonPosition.transform.position, summonPosition.transform.rotation);
        }

    }






}