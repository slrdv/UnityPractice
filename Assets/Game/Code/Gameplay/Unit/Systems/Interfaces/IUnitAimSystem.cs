using System;
using UnityEngine;
namespace Game
{
    public interface IUnitAimSystem : IDisposable
    {
        Vector3 CalculateRotation(Vector3 position);
    }
}
