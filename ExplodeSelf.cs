using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplodeSelf : MonoBehaviour
{
    [SerializeField] AudioSource PrefabRedExplode;
    public AudioSource RedExplode;

    public ParticleSystem Explosion;
    void OnCollisionEnter(Collision collision)
    {
        Transform RedCube = this.transform;
        Instantiate(Explosion, RedCube.position, RedCube.rotation);
        RedExplode = Instantiate(PrefabRedExplode);
        RedExplode.Play();
        Destroy(gameObject);

    }
}