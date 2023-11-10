using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    const float speed = 8;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            Move(Vector3.up);
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            Move(Vector3.down);
        }
    }

    private void Move(Vector3 vector)
    {
        // Calculate velocity
        velocity = vector * speed;

        // Calculate new position vector
        Vector3 newPosition = transform.position;
        newPosition += velocity * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f); 

        // Set position
        transform.position = newPosition;
    }
}
