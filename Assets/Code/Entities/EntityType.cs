using System;

namespace Code.Entities
{
    [Serializable]
    public enum EntityType
    {
        None,
        Floor,
        Goal,
        Box,
        Wall
    }
}