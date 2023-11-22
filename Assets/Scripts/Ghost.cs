using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    protected float speed = 6;
    public AudioClip spawnSound;
    public AudioClip hitSound;
    public GameObject normalRewardSignPrefab;
    public GameObject bonusRewardSignPrefab;
    
    protected Vector3 velocity;
    protected int points;
    protected AudioSource audioSource;

    protected bool isDead = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(this.spawnSound);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // Stop moving if gameover
        if (GameController.instance.IsGameOver) {
            GetComponent<Animator>().enabled = false;
            velocity = Vector3.zero;
            return;
        }

        if (transform.position.x > 10f) {
            DestroyGhost();
            GameController.instance.GhostSkippedBarrier();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Prevent trigger with same type of gameobjects
        if (collider.gameObject.tag == gameObject.tag) {
            return;
        }

        Die();
    }

    protected Vector3 GenerateRandomVector()
    {
        Vector3 targetVector = new Vector3(8.5f, Random.Range(-5f, 5f), 0f);

        return (targetVector - transform.position).normalized;
    }

    public void Die()
    {
        if (isDead) {
            return;
        }

        isDead = true;

        audioSource.PlayOneShot(this.hitSound);
        velocity = Vector3.zero;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Animator>().SetBool("isDead", true);
        GameController.instance.GhostKilled(points);

        // Add reward sign
        switch (points) {
            case 150:
                Instantiate(bonusRewardSignPrefab, transform.position + Vector3.up, Quaternion.identity);
                break;
            default:
                Instantiate(normalRewardSignPrefab, transform.position + Vector3.up, Quaternion.identity);
                break;
        }
    }

    private void DestroyGhost()
    {
        Destroy(gameObject);
    }
}
