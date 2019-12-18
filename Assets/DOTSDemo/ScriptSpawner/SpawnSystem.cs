using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static Unity.Mathematics.math;

public class SpawnSystem : JobComponentSystem
{
    EntityCommandBufferSystem m_EntityCommandBufferSystem;
    protected override void OnCreate()
    {
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();

    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();

        var jobHandle = Entities
            .WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
            .ForEach((Entity entity, int entityInQueryIndex, ref SpawnerComponent spawner) =>
            {
                for (var x = 0; x < spawner.spawnerValue; x++)
                {
                    var instance = commandBuffer.Instantiate(entityInQueryIndex, spawner.prefabToSpawn);

                    // Place the instantiated in a grid with some noise
                    var position = new float3(0, 12, 0);
                    commandBuffer.SetComponent(entityInQueryIndex, instance, new Translation { Value = position });

                }

                commandBuffer.DestroyEntity(entityInQueryIndex, entity);
            }).Schedule(inputDeps);

        m_EntityCommandBufferSystem.AddJobHandleForProducer(jobHandle);

        return jobHandle;
    }
}