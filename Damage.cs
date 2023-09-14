using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Damage : MonoBehaviour
{
    public Transform enemy = null; // intialize the enemy transform
    public static float EnemyHealth = 5;
    public float CubeDamage = 1;
    public GameObject EnemyPrefab;
    public ParticleSystem Explosion;

    /////////////////////////////////////////////////////
    // audio when enemy explodes
    [SerializeField] AudioSource PrefabExplode;
    public AudioSource Explode;
    /////////////////////////////////////////////////////

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("target hit");
            GameObject Enemy = collision.gameObject;
            TakeDamage(CubeDamage, Enemy);
        }

    }

    public void TakeDamage(float HitDamage, GameObject Enemy)
    {
        EnemyHealth = EnemyHealth - HitDamage;

        if (EnemyHealth <= 0)
        {
            GameObject enemyTag = GameObject.FindWithTag("Enemy"); // find the enemy via tag
            enemy = enemyTag.transform; // get enemy transform

            Explode = Instantiate(PrefabExplode);
            Explode.Play();
            
            Instantiate(Explosion, enemy.position, enemy.rotation);
            Destroy(Enemy);

            SpawnEnemies(1);
        }

    }

    public void SpawnEnemies(int Count)
    {
        int EnemyCount = Count;
        EnemyHealth = 2;

        for (int i = 0; i < EnemyCount; i++)
        {
            Vector3 EnemyVector = new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
            Quaternion EnemyRotation = Quaternion.Euler(0, 2, 0);
            Instantiate(EnemyPrefab, EnemyVector, EnemyRotation);
        }

    }
}
