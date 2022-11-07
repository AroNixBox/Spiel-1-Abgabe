using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    // Wichtig für meinen Restartbutton, sonst ist das Game noch pausiert.
    void Start()
    {
        Time.timeScale = 1;
    }

    //Spielreset, untere Line nur für Überprüfung in Konsole
    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("The button is working");
    }
}
