using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    [SerializeField] private AudioSource coinSound;
    [SerializeField] Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PowerupScale")
        {
            coinSound.Play();
            Destroy(collision.gameObject);
            player = player.GetComponent<Player>();
            player.AddScore();
            player.AddScore();
            player.AddScore();
            player.AddScore();
            player.AddScore();
            player.AddScore();
            player.AddScore();
            player.AddScore();
            player.AddScore();
            player.AddScore();

            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(ResetPower());
        }

    }
    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
