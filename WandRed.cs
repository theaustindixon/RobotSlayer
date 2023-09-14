using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandRed : MonoBehaviour
{
    public Transform WandSpawnPoint;
    public GameObject WandCubePrefab;
    public float WandSpeed = 10;
    public AudioSource Blaster;


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var WandSpellCube = Instantiate(WandCubePrefab, WandSpawnPoint.position, WandSpawnPoint.rotation);
            WandSpellCube.GetComponent<Rigidbody>().velocity = WandSpawnPoint.forward * WandSpeed;
            Blaster.Play();
        }
    }
}
