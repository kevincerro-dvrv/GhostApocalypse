using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDigit: MonoBehaviour
{
    public Sprite[] numbers;
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void RenderNumber(int number)
    {
        spriteRenderer.sprite = numbers[number];
    }
}
