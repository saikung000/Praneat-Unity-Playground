using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class DestroySystem : JobComponentSystem
{
    EntityCommandBufferSystem m_Barrier;

    protected override void OnCreate()
    {
        m_Barrier = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var commandBuffer = m_Barrier.CreateCommandBuffer().ToConcurrent();
        var job = Entities.WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
            .ForEach(
                (Entity entity, int entityInQueryIndex, ref Translation position) =>
                {

                    if (position.Value.y <= -10)
                    {
                        commandBuffer.DestroyEntity(entityInQueryIndex, entity);
                    }

                }).Schedule(inputDependencies);
        m_Barrier.AddJobHandleForProducer(job);
        return job;

    }
}