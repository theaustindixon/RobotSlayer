using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public Transform player = null; // intialize the player transform
    public float moveSpeed = 2.0f; // Speed at which the enemy moves
    public float rotationSpeed = 3.0f; // Speed at which the enemy rotates to face the player
    public float obstacleRange = 5.0f; // Look, a wall!


    /////////////////////////////////////////////////////
    // guns need bullets
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    
    /////////////////////////////////////////////////////
    // audio so enemy gun goes "pew pew"
    [SerializeField] AudioSource PrefabGunBlast;
    public AudioSource GunBlast;
    /////////////////////////////////////////////////////
    
    void Start()
    {
        GameObject playerTag = GameObject.FindWithTag("Player"); // find the player via tag
        player = playerTag.transform; // get player transform
    }
    void Update()
    {
        if (player == null)
        {
            // If the player is not found, stop following
            return;
        }

        Vector3 direction = player.position - transform.position; // Calculate the direction to the player
        direction.y = 0; // Ensure the enemy stays upright by ignoring the vertical component

        // Rotate the enemy to face the player
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move the enemy towards the player
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // If the enemy encounters an object via raycast
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            //////////////////////////////////////////////////////////////////
            // fire gun if player detected
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.gameObject.tag == "Player")
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

                GunBlast = Instantiate(PrefabGunBlast);
                GunBlast.Play(); // pew pew
            }
            //////////////////////////////////////////////////////////////////
            // If the enemy encounters a wall, make it try another way
            else if (hit.distance < obstacleRange) 
            {
                float angle = Random.Range(-110, 100);
                transform.Rotate(0, angle, 0);
            }
            //////////////////////////////////////////////////////////////////

        }

        // Correct the upright position
        Vector3 currentEulerAngles = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, currentEulerAngles.y, 0);
    }
}