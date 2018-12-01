using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Square : MonoBehaviour {

    public Color firstColor;
    private bool moveable = false;
    public bool attackable = false;
    public bool isEmpty = true;
    public GameObject unitIn = null;

	void Start () {

        firstColor = GetComponent<SpriteRenderer>().color;

    }
	
	// Update is called once per frame
	void Update () {

        //movimentação

            if (Controller.currentPhase == 1 && Controller.selectedUnit != null && transform.position.x <= Controller.selectedUnit.transform.position.x + Controller.selectedUnit.GetComponent<SoldierUnit>().speed && transform.position.x >= Controller.selectedUnit.transform.position.x - Controller.selectedUnit.GetComponent<SoldierUnit>().speed && transform.position.y <= Controller.selectedUnit.transform.position.y + Controller.selectedUnit.GetComponent<SoldierUnit>().speed && transform.position.y >= Controller.selectedUnit.transform.position.y - Controller.selectedUnit.GetComponent<SoldierUnit>().speed)
            {
            if ((transform.position.x + transform.position.y) - (Controller.selectedUnit.transform.position.x + Controller.selectedUnit.transform.position.y) < Controller.selectedUnit.GetComponent<SoldierUnit>().speed
                &&
                (Controller.selectedUnit.transform.position.x + Controller.selectedUnit.transform.position.y) - (transform.position.x + transform.position.y) < Controller.selectedUnit.GetComponent<SoldierUnit>().speed
                &&
                (Controller.selectedUnit.transform.position.x - Controller.selectedUnit.transform.position.y) - (transform.position.x - transform.position.y) > -Controller.selectedUnit.GetComponent<SoldierUnit>().speed
                &&
                (transform.position.x - transform.position.y) - (Controller.selectedUnit.transform.position.x - Controller.selectedUnit.transform.position.y) > -Controller.selectedUnit.GetComponent<SoldierUnit>().speed)

                moveable = true;

            else
                moveable = false;
            }
            else
                moveable = false;


        if (moveable)
        {
                if (firstColor == new Color(1, 1, 1, 1))
                {
                    GetComponent<SpriteRenderer>().color = Color.green;
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.5f);
                }
        }
        else
            if (!attackable)
            GetComponent<SpriteRenderer>().color = firstColor;

        //ataque normal
        if (Controller.selectedUnit != null && Controller.selectedUnit.GetComponent<SoldierUnit>().unitName != "Archer" && Controller.selectedUnit.GetComponent<SoldierUnit>().unitName != "Cleric" && Controller.currentPhase == 2 && transform.position.x <= Controller.selectedUnit.transform.position.x + 2 && transform.position.x >= Controller.selectedUnit.transform.position.x - 2 && transform.position.y <= Controller.selectedUnit.transform.position.y + 2 && transform.position.y >= Controller.selectedUnit.transform.position.y - 2)
        {
            if ((transform.position.x + transform.position.y) - (Controller.selectedUnit.transform.position.x + Controller.selectedUnit.transform.position.y) < 2
                &&
                (Controller.selectedUnit.transform.position.x + Controller.selectedUnit.transform.position.y) - (transform.position.x + transform.position.y) < 2
                &&
                (Controller.selectedUnit.transform.position.x - Controller.selectedUnit.transform.position.y) - (transform.position.x - transform.position.y) > -2
                &&
                (transform.position.x - transform.position.y) - (Controller.selectedUnit.transform.position.x - Controller.selectedUnit.transform.position.y) > -2)
            {
                attackable = true;
            }
            else
                attackable = false;
        }
        else
        //ataque arqueiro
        if (Controller.selectedUnit != null && Controller.selectedUnit.GetComponent<SoldierUnit>().unitName == "Archer" && Controller.currentPhase == 2)
            if(transform.position.x == Controller.selectedUnit.transform.position.x && transform.position.y < Controller.selectedUnit.transform.position.y + 3
            && transform.position.y > Controller.selectedUnit.transform.position.y - 3 || Controller.selectedUnit != null &&
            Controller.selectedUnit.GetComponent<SoldierUnit>().unitName == "Archer" && Controller.currentPhase == 2
            && transform.position.y == Controller.selectedUnit.transform.position.y && transform.position.x < Controller.selectedUnit.transform.position.x + 3
            && transform.position.x > Controller.selectedUnit.transform.position.x - 3)
            {
                attackable = true;
            }
            else
                attackable = false;
        else
        //cura do clerigo
        if (Controller.selectedUnit != null &&
            Controller.selectedUnit.GetComponent<SoldierUnit>().unitName == "Cleric" && Controller.currentPhase == 2
            && transform.position.x == Controller.selectedUnit.transform.position.x && transform.position.y < Controller.selectedUnit.transform.position.y + 3
            && transform.position.y > Controller.selectedUnit.transform.position.y - 3 || Controller.selectedUnit != null &&
            Controller.selectedUnit.GetComponent<SoldierUnit>().unitName == "Cleric" && Controller.currentPhase == 2
            && transform.position.y == Controller.selectedUnit.transform.position.y && transform.position.x < Controller.selectedUnit.transform.position.x + 3
            && transform.position.x > Controller.selectedUnit.transform.position.x - 3)
        {
            attackable = true;
        }
        else
            attackable = false;

        //pintar de vermelho

        if (unitIn != null && Controller.currentTurn % 2 == 0 && unitIn.gameObject.tag == "Player1" && !unitIn.GetComponent<SoldierUnit>().dead && Controller.selectedUnit != null && Controller.selectedUnit.GetComponent<SoldierUnit>().unitName != "Cleric"
            || unitIn != null && Controller.currentTurn % 2 != 0 && unitIn.gameObject.tag == "Player2" && !unitIn.GetComponent<SoldierUnit>().dead && Controller.selectedUnit != null && Controller.selectedUnit.GetComponent<SoldierUnit>().unitName != "Cleric")
            if (attackable && !isEmpty && new Vector2(Controller.selectedUnit.transform.position.x, Controller.selectedUnit.transform.position.y)
            != new Vector2(transform.position.x, transform.position.y))
            {
                if (firstColor == new Color(1, 1, 1, 1))
                {
                GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {
                GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
                }
            }

            else
                if (!moveable)
                    GetComponent<SpriteRenderer>().color = firstColor;

        //pintar de azul(cura)

        if (unitIn != null && Controller.currentTurn % 2 == 0 && unitIn.gameObject.tag == "Player2" && unitIn.GetComponent<SoldierUnit>().dead && Controller.selectedUnit != null && Controller.selectedUnit.GetComponent<SoldierUnit>().unitName == "Cleric"
            || unitIn != null && Controller.currentTurn % 2 != 0 && unitIn.gameObject.tag == "Player1" && unitIn.GetComponent<SoldierUnit>().dead && Controller.selectedUnit != null && Controller.selectedUnit.GetComponent<SoldierUnit>().unitName == "Cleric")
        {
            if (attackable && !isEmpty && new Vector2(Controller.selectedUnit.transform.position.x, Controller.selectedUnit.transform.position.y)
            != new Vector2(transform.position.x, transform.position.y))
            {
                GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 0.5f);
            }
                else
                    if (!moveable)
                        GetComponent<SpriteRenderer>().color = firstColor;
        }

    }

    void OnMouseDown()
    {
        if (moveable)
        {
            if(Controller.selectedUnit.GetComponent<SoldierUnit>().squareIn != null)
                Controller.selectedUnit.GetComponent<SoldierUnit>().squareIn.GetComponent<Square>().unitIn = null;

            Controller.selectedUnit.GetComponent<SpriteRenderer>().flipX = false;
            Controller.selectedUnit.transform.position = new Vector3(transform.position.x, transform.position.y, Controller.selectedUnit.transform.position.z);
            Controller.selectedUnit.GetComponent<SoldierUnit>().CheckPosition();
            Controller.ChangePhase();
        }
        else
            if(Controller.currentPhase == 1)
                Controller.selectedUnit = null;
    }

}
