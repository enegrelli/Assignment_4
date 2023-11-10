using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using UnityEngine;

[BurstCompile]
public struct AppleSpawnerSystem : ISystem
{
    public void OnCreate(ref SystemState state) { }

    public void OnDestroy(ref SystemState state) { }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (transform, properties) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<AppleSpawnerProperties>>())
        {
            // Increment the timer
            properties.Timer += Time.DeltaTime;

            // Check if it's time to spawn a new apple
            if (properties.Timer >= properties.SpawnInterval)
            {
                // Reset the timer
                properties.Timer = 0f;

                // Spawn a new apple entity
                var appleEntity = state.EntityManager.Instantiate(properties.ApplePrefab);

                // Add the necessary components to the spawned apple entity if needed
                state.EntityManager.SetComponentData(appleEntity, transform);

                // Add the Apple component to the spawned apple entity if needed
                state.EntityManager.AddComponent<Apple>(appleEntity);
            }
        }
    }
}

