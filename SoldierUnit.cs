using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUnit : MonoBehaviour {

    public string unitName = "";
    public float speed = 2f;
    public float range = 0;
    public int power = 1;
    public int hp = 1;
    public int startHp;
    public GameObject squareIn = null;
    public bool dead;
    public Sprite normalSprite;
    public Sprite deadSprite;
    public int deathCount = 0;
    public bool ressurected = false;
    public float waitToDie;

    void Start () {

        startHp = hp;
        CheckPosition();
        dead = false;

    }
	
	void Update () {

        if (dead)
        {
            waitToDie -= Time.deltaTime;

            if (waitToDie <= 0)
                GetComponent<Animator>().SetBool("Dead", true);

            if(this.unitName == "KingP1")
            {
                
            }

            if(deathCount+6 < Controller.currentTurn)
            {
                Destroy(gameObject);
            }
        }
        else
            if(GetComponent<Animator>() != null)
                GetComponent<Animator>().SetBool("Dead", false);

        if (dead && ressurected)
            Destroy(gameObject);

    }

    void OnMouseDown()
    {

        if (Controller.selectedUnit == this.gameObject && Controller.currentPhase == 1)
        {
            Controller.ChangePhase();
        }

        if (!dead && Controller.currentPhase == 1)
            if (Controller.currentTurn % 2 == 0 && this.gameObject.tag == "Player2" || Controller.currentTurn % 2 != 0 && this.gameObject.tag == "Player1")
                Controller.selectedUnit = this.gameObject;

       if (Controller.currentTurn % 2 == 0 && this.gameObject.tag == "Player1" || Controller.currentTurn % 2 != 0 && this.gameObject.tag == "Player2")
            Controller.attackedUnit = this.gameObject;

       if(Controller.currentTurn % 2 != 0 && this.gameObject.tag == "Player1" && Controller.selectedUnit != null && Controller.selectedUnit.GetComponent<SoldierUnit>().unitName == "Cleric"
            ||
          Controller.currentTurn % 2 == 0 && this.gameObject.tag == "Player2" && Controller.selectedUnit != null && Controller.selectedUnit.GetComponent<SoldierUnit>().unitName == "Cleric")
            Controller.attackedUnit = this.gameObject;

        if (Controller.attackedUnit != null && Controller.selectedUnit != null && Controller.selectedUnit.GetComponent<SoldierUnit>().unitName != "Cleric" && !Controller.attackedUnit.GetComponent<SoldierUnit>().dead && Controller.attackedUnit.GetComponent<SoldierUnit>().squareIn.GetComponent<Square>().attackable && Controller.currentPhase == 2)
        {
            Controller.Combat();
        }

        if (Controller.attackedUnit != null && Controller.attackedUnit.GetComponent<SoldierUnit>().dead && Controller.attackedUnit.GetComponent<SoldierUnit>().squareIn.GetComponent<Square>().attackable && Controller.currentPhase == 2)
        {
            Controller.Cure();
        }

    }

    private void OnMouseOver()
    {
            Controller.visualizedUnit = this.gameObject;
    }

    public void CheckPosition()
    {
        for(int i = 0; i < 64; i++)
        {
            string squareName;
            squareName = "Square ("+i+")";
            if(new Vector2 (transform.position.x, transform.position.y) == new Vector2(GameObject.Find(squareName).transform.position.x, GameObject.Find(squareName).transform.position.y))
            {
                squareIn = GameObject.Find(squareName);
                squareIn.GetComponent<Square>().unitIn = this.gameObject;
                GameObject.Find(squareName).GetComponent<Square>().isEmpty = false;
            }
        }
    }

}
