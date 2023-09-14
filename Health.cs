using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 20;
    public static float playerHealth = 20;
    [SerializeField] private HealthBar _healthBar;
    public AudioSource GameOverSound;
    public AudioSource HealUp;

    void Start()
    {
        playerHealth = _maxHealth;
        _healthBar.UpdateHealthBar(_maxHealth, playerHealth); // start with full healthbar
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Health") // if player touches a health powerup
        {
            playerHealth = _maxHealth;
            HealUp.Play();
            _healthBar.UpdateHealthBar(_maxHealth, playerHealth); // update healthbar

        }

        else if (collision.gameObject.tag == "Bullet") // enemy fire
        {
            
            playerHealth = playerHealth - 1;
            _healthBar.UpdateHealthBar(_maxHealth, playerHealth); // update healthbar

            if (playerHealth <= 0)
            {
                GameOverSound.Play(); // play sound so player knows they died
                SceneManager.LoadScene("SampleScene"); // if player dies, reload scene
            }
        }
    }
}
