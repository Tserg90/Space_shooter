using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolder
{
    private static int bestScore = 0;
    public static int BestScore
    {
        get
        {
            return bestScore;
        }
        set
        {
            if (bestScore < value) bestScore = value;
        }
    }
}
