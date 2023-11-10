using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct BasketSpawn : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var basketSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
        var ECB = basketSingleton.CreateCommandBuffer(state.WorldUnmanaged);

        foreach (var (transform, properties) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<BasketSpawnProperties>>())
        {
            if (properties.ValueRO.Respawn)
            {
                for (int index = 0; index < properties.ValueRO.NumBaskets; index++)
                {
                    var basket = ECB.Instantiate(properties.ValueRO.Basket);
                    var pos = new float3
                    {
                        y = properties.ValueRO.BasketBottomY + (properties.ValueRO.BasketSpacingY * index) + properties.ValueRO.NumBaskets
                    };

                    ECB.SetComponent(basket, LocalTransform.FromPosition(pos));
                }

                properties.ValueRW.Respawn = false;
            }
        }
    }
}
