using System.Collections.Generic;
using UnityEngine;
using ZMD;

public class Gravity : Singleton<Gravity>
{
    [field: SerializeField] public List<Asteroid> asteroids { get; private set; } = new();
    public void AddAsteroid(Asteroid newAsteroid) => asteroids.Add(newAsteroid);
    
}
