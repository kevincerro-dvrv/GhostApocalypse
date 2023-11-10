using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float speed = 6;
    public Vector3 velocity;
    private int points;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0f, 1f) < 0.3f) {
            // Perpendicular movement
            velocity = GenerateRandomVector() * speed;
            points = 100;
        } else {
            // Horizontal movement
            velocity = Vector3.right * speed;
            points = 150;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + velocity * Time.deltaTime;

        // Better to use OnBecameInvisible
        if (transform.position.x > 20f) {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Prevent trigger with same type of gameobjects
        if (collider.gameObject.tag == gameObject.tag) {
            return;
        }

        Die();
    }

    private Vector3 GenerateRandomVector()
    {
        Vector3 targetVector = new Vector3(8.5f, Random.Range(-5f, 5f), 0f);

        return (targetVector - transform.position).normalized;
    }

    private void Die()
    {
        velocity = Vector3.zero;
        GetComponent<Animator>().SetBool("isDead", true);
        GameController.instance.AddPoints(points);
    }

    private void DestroyGhost()
    {
        Destroy(gameObject);
    }
}
