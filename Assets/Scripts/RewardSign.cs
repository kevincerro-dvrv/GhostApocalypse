using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSign : MonoBehaviour
{
    public float speed = 2.5f;
    public float ttl = 1.2f;

    private float elapsedTime = 0;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Destroy(gameObject, ttl);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Move
        transform.position = transform.position + Vector3.up * speed * Time.deltaTime;

        // Decrease color alpha
        Color color = spriteRenderer.color;
        color.a = Mathf.Lerp(1f, 0f, elapsedTime / ttl);
        spriteRenderer.color = color;
    }
}
