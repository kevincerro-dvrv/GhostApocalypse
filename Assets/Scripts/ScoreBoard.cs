using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard: MonoBehaviour
{
    public ScoreDigit[] digits;

    public void ShowPoints(int points)
    {
        foreach (ScoreDigit digit in digits) {
            digit.RenderNumber(points % 10);
            points = points / 10;
        }
    }
}
