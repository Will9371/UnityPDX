using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public float startPositionRange;
    public float speedRange;
    public float scaleMaximum;
    public float scaleMinimum;

    void Start()
    {
        InitializeRandom();
    }
    
    void InitializeRandom()
    {
        transform.position = Random.insideUnitSphere * startPositionRange;
        transform.localScale = Random.Range(scaleMinimum, scaleMaximum) * Vector3.one;
        rb.velocity = Random.insideUnitSphere * speedRange;
    }
}
