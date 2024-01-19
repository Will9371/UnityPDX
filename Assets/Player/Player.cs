using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody rb;
    
    [Header("Movement")]
    [SerializeField] KeyCode forward = KeyCode.I;
    [SerializeField] KeyCode backward = KeyCode.K;
    [SerializeField] KeyCode left = KeyCode.J;
    [SerializeField] KeyCode right = KeyCode.L;
    [SerializeField] KeyCode up = KeyCode.U;
    [SerializeField] KeyCode down = KeyCode.O;
    
    [Header("Rotation")]
    [Tooltip("Rotation on the Y axis")]
    [SerializeField] KeyCode yawPositive = KeyCode.A;
    [Tooltip("Rotation on the Y axis")]
    [SerializeField] KeyCode yawNegative = KeyCode.D;
    [Tooltip("Rotation on the X axis")]
    [SerializeField] KeyCode pitchPositive = KeyCode.W;
    [Tooltip("Rotation on the X axis")]
    [SerializeField] KeyCode pitchNegative = KeyCode.S;
    [Tooltip("Rotation on the Z axis")]
    [SerializeField] KeyCode rollPositive = KeyCode.Q;
    [Tooltip("Rotation on the Z axis")]
    [SerializeField] KeyCode rollNegative = KeyCode.E;
    
    [Header("Other")]
    [SerializeField] KeyCode boost = KeyCode.Space;
    [SerializeField] KeyCode brake = KeyCode.B;
    
    [SerializeField] float engineStrength = 10;
    [SerializeField] float boostMultiplier = 5;
    [SerializeField] float rotationStrength = 1f;
    
    Vector3 moveInput;
    Vector3 rotationInput;
    bool boostApplied;
    bool brakeApplied;
    
    void Update()
    {
        moveInput = Vector3.zero;
        rotationInput = Vector3.zero;
        
        if (Input.GetKey(forward))
            moveInput += transform.forward;
        if (Input.GetKey(backward))    
            moveInput -= transform.forward;
        if (Input.GetKey(up))
            moveInput += transform.up;
        if (Input.GetKey(down))    
            moveInput -= transform.up;
        if (Input.GetKey(right))
            moveInput += transform.right;
        if (Input.GetKey(left))    
            moveInput -= transform.right;
            
        if (Input.GetKey(pitchPositive))
            rotationInput += Vector3.right;
        if (Input.GetKey(pitchNegative))    
            rotationInput += Vector3.left;
        if (Input.GetKey(yawPositive))
            rotationInput += Vector3.up;
        if (Input.GetKey(yawNegative))    
            rotationInput += Vector3.down;
        if (Input.GetKey(rollPositive))
            rotationInput += Vector3.forward;
        if (Input.GetKey(rollNegative))    
            rotationInput += Vector3.back;
            
        boostApplied = Input.GetKey(boost);
        brakeApplied = Input.GetKey(brake);
    }
    
    void FixedUpdate()
    {
        // Movement
        var forceMagnitude = boostApplied ? engineStrength * boostMultiplier : engineStrength;
        var force = brakeApplied ? GetBrakeForce() : forceMagnitude * moveInput;
        rb.AddForce(force);
        
        // Rotation
        // TBD: Apply braking to rotation
        rb.AddTorque(rotationStrength * rotationInput);
    }
    
    [SerializeField, Range(0,1)] float brakeForce;
    
    Vector3 GetBrakeForce()
    {
        return brakeForce * -rb.velocity;
    }
}
