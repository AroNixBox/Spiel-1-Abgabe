using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public GameObject objectToActivateAndDeactivate;
    public AudioSource bgMusic;
    Player player;

    // Wichtig f�r meinen Restartbutton, sonst ist das Game noch pausiert.
    void Start()
    {
        player = FindObjectOfType<Player>();
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            objectToActivateAndDeactivate.SetActive(false);
            Time.timeScale = 1;
            bgMusic.Play();
        }
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("The button is working");
    }
    //Spielreset, untere Line nur f�r �berpr�fung in Konsole
}
