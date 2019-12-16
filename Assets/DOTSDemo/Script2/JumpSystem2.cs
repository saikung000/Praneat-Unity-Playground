using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Entities;
using Unity.Burst;
using Unity.Physics;
using Unity.Collections;
using Unity.Mathematics;


public class JumpSystem2 : JobComponentSystem
{

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);

        return  Entities.WithAll<PlayerTag>().WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
        .ForEach((ref JumpComponent jump, ref PhysicsVelocity vel) =>
        {
            if(jumpPressed)
            {
                vel.Linear = new float3(vel.Linear.x, jump.jumpForce, vel.Linear.z);
            }
        }).Schedule(inputDeps);
    }
}

//https://github.com/Destrayon/Unity-DOTs-and-Physics-Example/blob/master/Assets/TestJob.cs