using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkGhost : Ghost
{
    private Vector3 targetPoint;
    private float lastStep;
    private float delay = 0f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        speed = 1f;
        lastStep = Time.time;
        points = 150;

        StartMovement();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if ((lastStep + delay) > Time.time) {
            return;
        }

        transform.position = transform.position + velocity * Time.deltaTime;
        if (Vector3.Distance(transform.position, targetPoint) < 0.05f) {
            velocity = Vector3.zero;
            transform.position = targetPoint;
            StartMovement();
        }
    }

    private void StartMovement()
    {
        lastStep = Time.time;
        delay = Random.Range(0.5f, 1f);

        float random = Random.Range(0f, 1f);
        if (random < 0.5f) {
            // Move in horizontal one step
            velocity = Vector3.right * speed;
        } else if (random < 0.75f) {
            // Vertical up movement
            velocity = Vector3.up * speed;
        } else {
            // Vertical down movement
            velocity = Vector3.down * speed;
        }  

        targetPoint = transform.position + velocity * Random.Range(0.5f, 1.2f);
        targetPoint.y = Mathf.Clamp(targetPoint.y, -5, 5);
    }
}
