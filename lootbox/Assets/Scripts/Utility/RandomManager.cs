using System;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager {
    public AnimationCurve cumulativeProbability;
    public static RandomManager randomManager;

    public void SetAnimationCurve()
    {
        cumulativeProbability = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.8f, 2), new Keyframe(1, 4));
        cumulativeProbability.SmoothTangents(1, -.05f);
        cumulativeProbability.SmoothTangents(2, -2f);
    }

    public float CurveWeightedRandom(AnimationCurve curve)
    {
        return curve.Evaluate(UnityEngine.Random.value);
    }

    // TODO
    public Type RandomList<T>(List<T> list)
    {
        System.Random random = new System.Random();
        return list[random.Next(list.Count)].GetType();
    }


}
