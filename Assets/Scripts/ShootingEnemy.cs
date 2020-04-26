using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float fireRate;
    private float nextFire;
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            Vector2 direction = (player.transform.position - transform.position).normalized * 10f;
            Debug.Log(direction);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y);
            nextFire = Time.time + fireRate;
        }
    }
}
