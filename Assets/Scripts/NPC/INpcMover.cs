using Main.StateMachine;
using UniRx;
using UnityEngine;

namespace Main.NPC
{
    public interface INpcMover
    {
        public Component Main { get; }
        public ReactiveCommand PathReached { get; }
        public void SetPath();
        public void BreakPath();
    }
}