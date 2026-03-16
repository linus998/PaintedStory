using UnityEngine;

public class GunMechanics : MonoBehaviour
{
    public float fireRate = 0.5f; // Time between shots
    public GameObject bulletPrefab; // Prefab for the bullet
    public Transform firePoint; // Point from which bullets are fired

    private float nextFireTime = 0f; // Track when the gun can fire next

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Removed InvokeRepeating
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime) // Left mouse button
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogError("Bullet prefab or fire point not assigned!");
        }
    }
}
