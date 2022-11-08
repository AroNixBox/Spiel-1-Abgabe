using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public GameObject objectToActivateAndDeactivate;
    public AudioSource bgMusic;
    public static int Number = 0;

    // Wichtig für meinen Restartbutton, sonst ist das Game noch pausiert.
    void Start()
    {
        Time.timeScale = 0;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            objectToActivateAndDeactivate.SetActive(false);
            Time.timeScale = 1;
            bgMusic.Play();
        }
        if (Time.timeScale <= 0)
        {
            bgMusic.Stop();
        }
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("The button is working");
    }
    //Spielreset, untere Line nur für Überprüfung in Konsole
}
