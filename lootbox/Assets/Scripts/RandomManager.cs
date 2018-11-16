using UnityEngine;

public class RandomManager : MonoBehaviour {
    [SerializeField] private AnimationCurve cumulativeProbability;
    private Keyframe baseKeyFrame = new Keyframe (0, 0);
    private Keyframe middleKeyFrame = new Keyframe(0.8f, 2);
    private Keyframe endingKeyFrame = new Keyframe(1, 5);
    private float middleSmooth = -.05f;
    private float endingSmooth = -2f;


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

    private void Start()
    {
        cumulativeProbability = new AnimationCurve(baseKeyFrame, middleKeyFrame, endingKeyFrame);
        cumulativeProbability.SmoothTangents(1, middleSmooth);
        cumulativeProbability.SmoothTangents(2, endingSmooth);
    }

    public float CurveWeightedRandom(AnimationCurve curve)
    {
        return curve.Evaluate(Random.value);
    }
}
