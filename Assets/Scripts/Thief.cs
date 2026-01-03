using UnityEngine;

public class Thief : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;

    [Header("Animación")]
    [SerializeField] private Animator anim;

    [Header("Camera-relative")]
    [SerializeField] private Transform cam;

    private bool _caught = false;

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (anim == null) anim = GetComponent<Animator>();
        if (cam == null && Camera.main != null) cam = Camera.main.transform;

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(h, 0f, v);
        bool moving = input.sqrMagnitude > 0.001f;

        if (anim != null) anim.SetBool("Moving", moving);

        if (!moving)
        {
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
            rb.angularVelocity = Vector3.zero;
            return;
        }

        input = input.normalized;

        
        Vector3 forward = cam ? cam.forward : Vector3.forward;
        Vector3 right = cam ? cam.right : Vector3.right;

        forward.y = 0f; right.y = 0f;
        forward.Normalize(); right.Normalize();

        Vector3 dir = (forward * input.z + right * input.x).normalized;

        rb.linearVelocity = new Vector3(dir.x * moveSpeed, rb.linearVelocity.y, dir.z * moveSpeed);

        Quaternion targetRot = Quaternion.LookRotation(dir, Vector3.up);
        rb.MoveRotation(targetRot);
    }

    public void CaughtByGuard()
    {
        if (_caught) return;
        _caught = true;

        FindFirstObjectByType<GameManager>()?.OnThiefCaught();
    }
}

