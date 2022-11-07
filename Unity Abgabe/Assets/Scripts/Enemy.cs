using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioSource playerHitSoundEffect;
    public float speed;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hammer")
        {
            player.AddScore();
            Destroy(gameObject);
        }
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            player.TakeDamage();
            speed = 0;
            transform.parent = player.transform;
        }
        if (other.tag == "Player")
        {
            playerHitSoundEffect.Play();
        }
    }
}
