using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float carSpeed;
    private bool turningLeft;
    private bool turningRight;
    private Rigidbody rb;
    private int i = 1;

    // Start is called before the first frame update
    void Start() {
        carSpeed = 5.0f;
        turningLeft = false;
        turningRight = false;
        rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) { turningLeft = true; }
        if (Input.GetKeyDown(KeyCode.D)) { turningRight = true; }
    }
    void FixedUpdate()
    {
        if (turningLeft == true)
        {
            i++;
            Vector3 rotationVector = new Vector3(transform.rotation.x, transform.rotation.y + 1 * carSpeed + i, transform.rotation.z);
            Quaternion rotation = Quaternion.Euler(rotationVector);
            // rotates the object then when you move forward you go that way
            rb.rotation = rotation;
        }  
    }
}
