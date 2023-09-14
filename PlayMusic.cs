using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource Jabberwock;
    void OnTriggerEnter(Collider collision)
    {
        Jabberwock.Play();

    }
}
