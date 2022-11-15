using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //sound
    [SerializeField] private AudioSource gameOverFx;
    [SerializeField] private AudioSource speedPowerupSoundEffect;

    //Make Scene In(visible)
    public GameObject objectToActivateAndDeactivate;
    private SpriteRenderer myRenderer;

    public int health;
    int score;
    public TMP_Text healthDisplay, scoreDisplay;

    [SerializeField]
    private float speed;

    [SerializeField] private AudioSource hammerSoundEffect;

    [SerializeField]
    private float rotationSpeed;


    void Start ()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        //Rotation mit Movement zusammen. Drehung in Richtung von Bewegung

        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);
        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    //Take Damage, lose health, Zeit Anhalten und GameOverScreen wenn tot
    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            gameOverFx.Play();
            objectToActivateAndDeactivate.SetActive(true);
            Time.timeScale = 0;
        }
        healthDisplay.text = "Health: " + health;
    }
    //Score Added
    public void AddScore()
    {
        hammerSoundEffect.Play();
        score++;
        scoreDisplay.text = "Score: " + score;
    }
    //Powerup Effect Geschwindigkeit verdoppeln
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (score == 18 || collision.tag == "PowerupScale")
        {
            speed = 12;
        }
        if (speed == 5f)
        {
            if (collision.tag == "Powerup")
            {
                speedPowerupSoundEffect.Play();
                Destroy(collision.gameObject);
                speed = 10f;
                myRenderer.color = Color.blue;
                StartCoroutine(ResetPower());
                AddScore2();
                AddScore2();
                AddScore2();
                AddScore2();
                AddScore2();
            }
        }
        if (speed == 12f)
        {
            if (collision.tag == "Powerup")
            {
                speedPowerupSoundEffect.Play();
                Destroy(collision.gameObject);
                speed = 22f;
                myRenderer.color = Color.green;
                StartCoroutine(ResetPower2());
                AddScore2();
                AddScore2();
                AddScore2();
                AddScore2();
                AddScore2();
                AddScore2();
                AddScore2();
                AddScore2();
            }
        }


    }
    //Powerup Reset effects
    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(3);
        myRenderer.color = Color.white;

        if (speed == 12)
        {
            speed = 12;
        }
        if (speed == 10)
        {
            speed = 5;
        }
    }
    private IEnumerator ResetPower2()
    {
        yield return new WaitForSeconds(3);
        speed = 12;
        myRenderer.color = Color.white;
    }
    public void AddScore2()
    {
        score++;
        scoreDisplay.text = "Score: " + score;
    }
}