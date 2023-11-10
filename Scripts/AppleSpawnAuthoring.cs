using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

public class AppleSpawnerAuthoring : MonoBehaviour
{
    public GameObject applePrefab;
    public int initialAppleCount;
    public float spawnInterval;

    private class AppleSpawnerBaker : Baker<AppleSpawnerAuthoring>
    {
        public override void Bake(AppleSpawnerAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var propertiesComponent = new AppleSpawnerProperties
            {
                ApplePrefab = authoring.applePrefab,
                InitialAppleCount = authoring.initialAppleCount,
                SpawnInterval = authoring.spawnInterval,
                Timer = 0f
            };

            AddComponent(entity, propertiesComponent);

        }
    }

    public struct AppleSpawnerProperties : IComponentData
    {
        public GameObject ApplePrefab;
        public int InitialAppleCount;
        public float SpawnInterval;
        public float Timer;
    }
}
