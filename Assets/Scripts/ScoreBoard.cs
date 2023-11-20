using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard: MonoBehaviour
{
    public GameObject[] digits;
    public Sprite[] numbers;

    public void ShowPoints(int points)
    {
        int pointsAux = points;
        int digit = 0;
        while(pointsAux > 0)
        {
            RenderNumber(digit, pointsAux % 10);
            pointsAux = pointsAux / 10;
            digit++;
        }
    }

    private void RenderNumber(int digit, int number)
    {
        digits[digit].GetComponent<SpriteRenderer>().sprite = numbers[number];
    }
}
