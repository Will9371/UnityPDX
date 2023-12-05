using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody rb;
    Gravity gravity;
    
    [Header("Settings")]
    public float startPositionRange;
    public float speedRange;
    public float scaleMaximum;
    public float scaleMinimum;
    
    [Header("Calculated/Debug")]
    public float volume;

    void Start()
    {
        gravity = Gravity.instance;
        gravity.AddAsteroid(rb);
        InitializeRandom();
    }
    
    void InitializeRandom()
    {
        rb.position = Random.insideUnitSphere * startPositionRange;
        transform.localScale = Random.Range(scaleMinimum, scaleMaximum) * Vector3.one;
        
        var scaleX = transform.localScale.x;
        var radius = scaleX/2f;
        volume = 4f/3f * Mathf.PI * Mathf.Pow(radius, 3);
        rb.mass = volume;
        rb.AddForce(Random.insideUnitSphere * speedRange, ForceMode.VelocityChange);
    }
    
    void FixedUpdate() => gravity.ApplyGravity(rb);
}
