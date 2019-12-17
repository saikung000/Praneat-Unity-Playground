using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject Prefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
        }
    }
    void Spawn()
    {
        // Create entity prefab from the game object hierarchy once
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld,  new BlobAssetStore());
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab, settings);
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        // Efficiently instantiate a bunch of entities from the already converted entity prefab
        var instance = entityManager.Instantiate(prefab);

        // Place the instantiated entity in a grid with some noise
        var position = transform.TransformPoint(new float3(0 , 12, 0));
        entityManager.SetComponentData(instance, new Translation { Value = position });

    }
}
