using UnityEngine;

namespace Game
{
    public static class RandomUtils
    {
        public static Vector3 GetRandomDirectionInCircle()
        {
            Vector2 direction = Random.insideUnitCircle;
            return new Vector3(direction.x, 0, direction.y);
        }

        public static T GetRandomElement<T>(T[] array)
        {
            return array[Random.Range(0, array.Length)];
        }
    }
}
