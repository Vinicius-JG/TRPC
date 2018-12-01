using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour {

    public void Restart()
    {
        Controller.selectedUnit = null;
        Controller.attackedUnit = null;
        Controller.visualizedUnit = null;
        Controller.currentPhase = 1;
        Controller.currentTurn = 1;
        SceneManager.LoadScene("Game");
    }

    public void Finish()
    {
        Application.Quit();
    }
}
