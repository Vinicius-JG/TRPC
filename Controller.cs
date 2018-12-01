using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Controller : MonoBehaviour {

    static public GameObject selectedUnit = null;
    static public GameObject attackedUnit = null;
    static public GameObject visualizedUnit = null;
    static public int currentPhase = 1;
    static public int currentTurn = 1;
    public GameObject endP1;
    public GameObject endP2;

    void Start () {

    }
	
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            attackedUnit = null;
            selectedUnit = null;
        }

    }

    public static void ChangePhase()
    {

        if (currentPhase == 2)
        {
            ChangeTurn();
        }
            else
                currentPhase = 2;
    }

    public static void ChangeTurn()
    {
        currentPhase = 1;
        selectedUnit = null;
        attackedUnit = null;
        currentTurn += 1;
    }

    public static void Combat()
    {
        attackedUnit.GetComponent<SoldierUnit>().hp -= selectedUnit.GetComponent<SoldierUnit>().power;
        //flipar quando necessario begin
        if (selectedUnit.gameObject.tag == "Player1" && selectedUnit.transform.position.x > attackedUnit.transform.position.x || selectedUnit.gameObject.tag == "Player2" && selectedUnit.transform.position.x < attackedUnit.transform.position.x)
            selectedUnit.GetComponent<SpriteRenderer>().flipX = true;
        else
            selectedUnit.GetComponent<SpriteRenderer>().flipX = false;
        //flipar quando necessario end
        selectedUnit.GetComponent<Animator>().SetTrigger("Attack");
        if (attackedUnit.GetComponent<SoldierUnit>().hp <= 0)
        {
            attackedUnit.GetComponent<SoldierUnit>().hp = 0;
            attackedUnit.GetComponent<SoldierUnit>().deathCount = currentTurn;
            attackedUnit.GetComponent<SoldierUnit>().dead = true;
            if(attackedUnit.name == "KingP1")
            {
                Instantiate(GameObject.Find("GameController").GetComponent<Controller>().endP2);
            }

            if (attackedUnit.name == "KingP2")
            {
                Instantiate(GameObject.Find("GameController").GetComponent<Controller>().endP1);
            }

        }

        ChangeTurn();
    }

    public static void Cure()
    {
        attackedUnit.GetComponent<SoldierUnit>().hp = attackedUnit.GetComponent<SoldierUnit>().startHp;
        if (selectedUnit.GetComponent<Animator>() != null)
        {
            selectedUnit.GetComponent<Animator>().SetTrigger("Attack");
        }
        attackedUnit.GetComponent<SpriteRenderer>().sprite = attackedUnit.GetComponent<SoldierUnit>().normalSprite;
        attackedUnit.GetComponent<SoldierUnit>().dead = false;
        attackedUnit.GetComponent<SoldierUnit>().ressurected = true;
        ChangeTurn();
    }

}
