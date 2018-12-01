using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text p_name, p_power, p_range, p_speed, p_hp;
    public Text e_name, e_power, e_range, e_speed, e_hp;
    public Text PlayerTurn;
    public Button end;

    void Start () {
		
	}

	void Update () {

        if (Controller.currentTurn % 2 == 0)
        {
            PlayerTurn.color = new Color(0, 0, 1);
            PlayerTurn.text = "Blue Player Turn";
        }
        else
        {
            PlayerTurn.color = new Color(1, 0, 0);
            PlayerTurn.text = "Red Player Turn";
        }

        if (Controller.visualizedUnit != null)
        {

            if (Controller.visualizedUnit.gameObject.tag == "Player1")
            {
                e_name.text = Controller.visualizedUnit.GetComponent<SoldierUnit>().unitName;
                e_power.text = "Power: " + Controller.visualizedUnit.GetComponent<SoldierUnit>().power;
                e_range.text = "Range: " + Controller.visualizedUnit.GetComponent<SoldierUnit>().range;
                e_speed.text = "Speed: " + Controller.visualizedUnit.GetComponent<SoldierUnit>().speed;
                if (!Controller.visualizedUnit.GetComponent<SoldierUnit>().dead)
                    e_hp.text = "HP: " + Controller.visualizedUnit.GetComponent<SoldierUnit>().hp;
                else
                    e_hp.text = "Turns left: " + (Controller.visualizedUnit.GetComponent<SoldierUnit>().deathCount + 7 - Controller.currentTurn);
            }

            if (Controller.visualizedUnit.gameObject.tag == "Player2")
            {
                p_name.text = Controller.visualizedUnit.GetComponent<SoldierUnit>().unitName;
                p_power.text = "Power: " + Controller.visualizedUnit.GetComponent<SoldierUnit>().power;
                p_range.text = "Range: " + Controller.visualizedUnit.GetComponent<SoldierUnit>().range;
                p_speed.text = "Speed: " + Controller.visualizedUnit.GetComponent<SoldierUnit>().speed;
                if (!Controller.visualizedUnit.GetComponent<SoldierUnit>().dead)
                    p_hp.text = "HP: " + Controller.visualizedUnit.GetComponent<SoldierUnit>().hp;
                else
                    p_hp.text = "Turns left: " + (Controller.visualizedUnit.GetComponent<SoldierUnit>().deathCount + 7 - Controller.currentTurn);
            }
        }

        if (Controller.currentPhase == 1)
            end.interactable = false;
        else
            end.interactable = true;

    }

    public void EndButton()
    {
        Controller.ChangeTurn();
    }

}
