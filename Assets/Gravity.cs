using System.Collections.Generic;
using UnityEngine;
using ZMD;

public class Gravity : Singleton<Gravity>
{
    [SerializeField] float gravityConstant = 9.8f;

    [field: SerializeField] public List<Rigidbody> rbs { get; private set; } = new();
    public void AddAsteroid(Rigidbody newRb) => rbs.Add(newRb);

    public void ApplyGravity(Rigidbody source)
    {
        foreach (var other in rbs)
        {
            if (source == other) continue;
            var distance = Vector3.Distance(source.position, other.position);
            var direction = (source.position - other.position).normalized;
            var force = (gravityConstant * source.mass * other.mass) / Mathf.Pow(distance, 2);
            other.AddForce(force * direction);
        }
    }
}
