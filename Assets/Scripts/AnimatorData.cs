using UnityEngine;

public static class AnimatorData
{
    public static class Parameters
    {
        public static readonly int Run = Animator.StringToHash(nameof(Run));
        public static readonly int Jump = Animator.StringToHash(nameof(Jump));
    }
}
