// ============================================================
// includes
// ============================================================
using UnityEngine;

// ============================================================
// pubic class for paint brush item in game
// ============================================================
public class PaintBrush : MonoBehaviour
{   
    // -------------------------------------
    // ------------- VARIABLES -------------
    // -------------------------------------

    public float fireRate = 0.5f;           // paint bullet frequentie
    public GameObject bulletPrefab;         // 3d item prefab
    public Transform firePoint;             // point on player (gun) from which paint ball shoots

    private float TimeOfNextFire = 0f;      // timestamp at which the gun can fire again

    // ------------------------------------
    // ------------- FUNTIONS -------------
    // ------------------------------------
    
    // start function (init on new player)
    void Start()
    {
    }

    // run every tick and check for shot
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= TimeOfNextFire)      // check fire button and timestamp
        {
            Fire();                                                         // call fire function
            TimeOfNextFire = Time.time + fireRate;                            // set the next timestamp to fire at
        }  
    }

    // creates new bullet instance
    void Fire()
    {
        if (bulletPrefab != null && firePoint != null)                          // check for bullet prefab
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);  // create a bullet at the firePoint 
        }
        else                                                                    // if bullet or prefab is missing
        {
            Debug.LogError("Bullet prefab or fire point not assigned!");        // error log
        }
    }
}