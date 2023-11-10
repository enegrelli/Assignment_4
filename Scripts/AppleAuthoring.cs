using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class AppleAuthoring : MonoBehaviour
{
    private class AppleBaker : Baker<AppleAuthoring>
    {
        public override void Bake(AppleAuthoring authoring)
        {
            var appleEntity = GetEntity(TransformUsageFlags.Dynamic);
            var applePos = authoring.transform.position;
            AddComponent(appleEntity, new Apple
            {
                SpawnPos = applePos
            });
        }
    }
}


public struct Apple : IComponentData
{
    public float3 SpawnPos;
}