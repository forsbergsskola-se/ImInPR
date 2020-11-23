using System;
using UnityEngine;
using static ResolutionRelation;

public class BlackBars : MonoBehaviour
{
    private void Start()
    {
        if (Math.Abs(AspectRatio - 1.77f) < 0.01f)
        {
            Debug.Log("16/9");
        }
    }
}
