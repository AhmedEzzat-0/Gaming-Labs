using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectable : MonoBehaviour
{
    //public AudioClip coinSound;
    public AudioClip coin1;
    public AudioClip coin2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerStats.score++;

            AudioManager.Instance.PlayRandomSFX(coin1, coin2);

            Debug.Log("Score: " + PlayerStats.score);

            Destroy(gameObject);
        }
    }
}