using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float carSpeed;
    private bool turningLeft;
    private bool turningRight;

    // Start is called before the first frame update
    void Start() {
        carSpeed = 5.0f;
        turningLeft = false;
        turningRight = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) { turningLeft = true; }
        if (Input.GetKeyDown(KeyCode.D)) { turningRight = true; }
    }
    void FixedUpdate()
    {
        
    }
}
