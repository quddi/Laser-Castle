using Unity.Entities;

namespace Code.Extensions
{
    public static class Constants
    {
        public static EntityManager DefaultEntityManager => World.DefaultGameObjectInjectionWorld?.EntityManager ?? default;
    }
}