using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGhost : Ghost
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        if (Random.Range(0f, 1f) < 0.3f) {
            // Perpendicular movement
            velocity = GenerateRandomVector() * speed;
            points = 150;
        } else {
            // Horizontal movement
            velocity = Vector3.right * speed;
            points = 100;
        }   
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
     
        // Move ghost
        transform.position = transform.position + velocity * Time.deltaTime;
    }
}
