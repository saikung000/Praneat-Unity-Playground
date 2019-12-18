using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct SpawnerComponent : IComponentData
{
    public Entity prefabToSpawn;
    public float spawnerValue;
}
