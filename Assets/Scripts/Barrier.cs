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
        velocity = vector * speed;
        transform.position = transform.position + velocity * Time.deltaTime;

        if (transform.position.y < -4) {
            transform.position = new Vector3(transform.position.x, -4, transform.position.z);
        } else if(transform.position.y > 4) {
            transform.position = new Vector3(transform.position.x, 4, transform.position.z);
        }
    }
}
