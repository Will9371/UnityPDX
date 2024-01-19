using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] KeyCode forward = KeyCode.UpArrow;
    [SerializeField] KeyCode backward = KeyCode.DownArrow;
    [SerializeField] KeyCode boost = KeyCode.Space;
    [SerializeField] KeyCode brake = KeyCode.B;
    [SerializeField] float engineStrength = 10;
    [SerializeField] float boostMultiplier = 5;
    
    Vector3 input;
    bool boostApplied;
    bool brakeApplied;
    
    void Update()
    {
        input = Vector3.zero;
        
        if (Input.GetKey(forward))
            input += transform.forward;
        if (Input.GetKey(backward))    
            input -= transform.forward;
            
        boostApplied = Input.GetKey(boost);
        brakeApplied = Input.GetKey(brake);
    }
    
    void FixedUpdate()
    {
        var forceMagnitude = boostApplied ? engineStrength * boostMultiplier : engineStrength;
        var force = brakeApplied ? GetBrakeForce() : forceMagnitude * input;
        rb.AddForce(force);
    }
    
    [SerializeField, Range(0,1)] float brakeForce;
    
    Vector3 GetBrakeForce()
    {
        return brakeForce * -rb.velocity;
    }
}
