using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public Transform WandSpawnPoint;
    public GameObject WandCubePrefab;
    public float WandSpeed = 10;
    public AudioSource Blaster;

  
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // make aiming sights
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnGUI()
    {
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var WandSpellCube = Instantiate(WandCubePrefab, WandSpawnPoint.position, WandSpawnPoint.rotation);
            WandSpellCube.GetComponent<Rigidbody>().velocity = WandSpawnPoint.forward * WandSpeed;
            Blaster.Play();
        }
    }
}
