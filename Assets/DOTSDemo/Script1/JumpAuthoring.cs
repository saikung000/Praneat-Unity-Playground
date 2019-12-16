using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;


public class JumpAuthoring : MonoBehaviour , IConvertGameObjectToEntity
{
    public float jumpForce;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new JumpComponent { jumpForce = jumpForce });
    }
}