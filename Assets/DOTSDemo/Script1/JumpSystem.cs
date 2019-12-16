using Unity.Entities;
using Unity.Physics;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class JumpSystem : JobComponentSystem
{
    [BurstCompile]
    struct JumpJob : IJobForEach<JumpComponent,PhysicsVelocity>
    {
        public bool jumpPressed;
        public void Execute(ref JumpComponent jump, ref PhysicsVelocity vel )
        {
            if(jumpPressed)
            {
                vel.Linear = new float3(vel.Linear.x, jump.jumpForce, vel.Linear.z);
            }
        }
    }


    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
    
        var job = new JumpJob()
        {
            jumpPressed = Input.GetKeyDown(KeyCode.Space)
        };

        return job.Schedule(this, inputDependencies);
    }
}

//https://github.com/Unity-Technologies/unite2019-scenedatatodots/blob/master/Assets/RotateCube/RotateSystem.cs