using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class BasketAuthoring : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets;

    private class BasketBaker : Baker<BasketAuthoring>
    {
        public override void Bake(BasketAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var basketPosition = authoring.transform.position;
            var properties = new BasketProperties
            {
                prefab = GetEntity(authoring.basketPrefab, TransformUsageFlags.Dynamic),
                numBaskets = authoring.numBaskets,
            };

            AddComponent(entity, properties);

        }
    }
}

public struct BasketProperties : IComponentData
{
    public Entity prefab;
    public int numBaskets;
}
