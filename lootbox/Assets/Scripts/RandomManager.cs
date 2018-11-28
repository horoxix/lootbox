using System;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager  {
    [SerializeField] private AnimationCurve cumulativeProbability;

    public static System.Random random = new System.Random();
    public static RandomManager randomManager;

    public AnimationCurve CumulativeProbability
    {
        get
        {
            return cumulativeProbability;
        }

        set
        {
            cumulativeProbability = value;
        }
    }

    public void SetAnimationCurve()
    {
        cumulativeProbability = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.8f, 2), new Keyframe(1, 4));
        cumulativeProbability.SmoothTangents(1, -.05f);
        cumulativeProbability.SmoothTangents(2, -2f);
    }

    private void Start()
    {
        SetAnimationCurve();
    }

    public float CurveWeightedRandom(AnimationCurve curve)
    {
        return curve.Evaluate(UnityEngine.Random.value);
    }

    // TODO
    public Type RandomList<T>(List<T> list)
    {
        return list[random.Next(list.Count)].GetType();
    }


}
