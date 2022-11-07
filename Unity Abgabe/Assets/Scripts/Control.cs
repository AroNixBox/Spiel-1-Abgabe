using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    // Wichtig f�r meinen Restartbutton, sonst ist das Game noch pausiert.
    void Start()
    {
        Time.timeScale = 1;
    }

    //Spielreset, untere Line nur f�r �berpr�fung in Konsole
    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("The button is working");
    }
}
