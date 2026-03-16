using UnityEngine;

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Set player's movement speed.
    //public float rotationSpeed = 120.0f; // Set player's rotation speed.
    public float jumpForce = 5.0f;

    private Rigidbody rb; // Reference to player's Rigidbody.
    private bool isGrounded = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
        }
    }

    // Check if player is touching something from below
    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            // Check if het contactpunt onder de speler zit (normaal wijst omhoog)
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        // Move player based on vertical input.
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // move player based on horizontal input.
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 slide = transform.right * moveHorizontal * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + slide);
    }
}