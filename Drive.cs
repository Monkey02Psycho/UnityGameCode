﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    void FixedUpdate()
    {

    }

    private void goToPoint(Vector3 point, Transform position)
    {
        position.position = new Vector3(transform.position)
    }
}
