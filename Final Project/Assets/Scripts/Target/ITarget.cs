using UnityEngine;

namespace Player
{
    public interface ITarget
    {
        Vector3 Position { get; }
        void EnableTargetIndicator();
        void DisableTargetIndicator();
    }
}