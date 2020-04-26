using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    [SerializeField]
    private float frequency;

    [SerializeField]
    private float fireRate;
    private float nextFire;


    [SerializeField]
    private GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && (Time.time > nextFire))
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * 10f;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y);
            nextFire = Time.time + fireRate;
        }
    }
}
