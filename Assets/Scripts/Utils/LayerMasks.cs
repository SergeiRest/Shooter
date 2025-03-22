using UnityEngine;

namespace Main
{
    public static class LayerMasks
    {
        public static int Default = 1 << LayerMask.NameToLayer(Layers.Default);
        public static int Player = 1 << LayerMask.NameToLayer(Layers.Player);

        private class Layers
        {
            public const string Player = "Player";
            public const string Default = "Default";
        }
    }
}