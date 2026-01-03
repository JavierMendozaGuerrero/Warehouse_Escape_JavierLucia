using UnityEngine;
using System;

public class GuardRobot : MonoBehaviour
{
    public static event Action FirstAlarmTriggered;  
    private static bool firstAlarmAlreadySent = false;  
    public static void ResetAlarmEvent()
    {
        firstAlarmAlreadySent = false;
    }

    private Vector3 escapeDir = Vector3.zero;
    private float escapeTimer = 0f;
    [SerializeField] private float escapeDuration = 0.6f; 

    private Vector3 lastPos;
    private float stuckTimer = 0f;
    [SerializeField] private float stuckThreshold = 0.05f;    
    [SerializeField] private float stuckTimeToEscape = 0.5f;  
     
    private float escapeCooldown = 0f;
    [SerializeField] private float escapeCooldownTime = 0.3f;

    [Header("Movimiento")]
    [SerializeField] public float moveSpeed = 4.5f;
    [SerializeField] public float rotationSpeed = 14f;

    [Header("Referencias")]
    [SerializeField] public Transform thief;

    [Header("Patrulla")]
    [SerializeField] public Transform[] waypoints;

    [Header("Evitar obstaculos")]
    [SerializeField] public LayerMask obstacleMask;
    [SerializeField] public float checkDistance = 1.7f;
    [SerializeField] public float avoidAngle = 50f;

    [Tooltip("Radio del SphereCast para detectar paredes con más fiabilidad.")]
    [SerializeField] private float castRadius = 0.25f;

    [Tooltip("Si se queda encajado, retrocede un poco a esta velocidad.")]
    [SerializeField] private float stuckBackUpSpeed = 2.0f;

    [Tooltip("Altura desde la que se lanzan los casts (para no rozar el suelo).")]
    [SerializeField] private float castHeight = 0.25f;

    [SerializeField] private Rigidbody rb;

    private StateMachine sm;
    private PatrolState patrolState;
    private ChaseState chaseState;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) rb = gameObject.AddComponent<Rigidbody>();

        rb.isKinematic = true;
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        sm = new StateMachine(this);
    }

    private void Start()
    {
        lastPos = transform.position;

        if (thief == null)
        {
            Thief foundThief = FindFirstObjectByType<Thief>();

            if (foundThief != null) thief = foundThief.transform;
            else Debug.LogWarning($"[{name}] No se encontró ningún Thief en la escena");
        }

        patrolState = new PatrolState();
        chaseState = new ChaseState();

        sm.SetState(patrolState);
    }

    private void FixedUpdate()
    {
        sm.Update();
    }

    public void OnAlarm(Vector3 alarmPos)
    {
        if (sm == null || chaseState == null)
        {
            return;
        }

        if (!firstAlarmAlreadySent)
        {
            firstAlarmAlreadySent = true;
            FirstAlarmTriggered?.Invoke();
        }

        sm.SetState(chaseState);
    }

    public void MoveToAvoiding(Vector3 targetPos)
    {
        Vector3 pos = transform.position;
        Vector3 toTarget = targetPos - pos;
        toTarget.y = 0f;

        if (toTarget.sqrMagnitude < 0.01f)
            return;

        Vector3 desiredDir = toTarget.normalized;
        Vector3 origin = pos + Vector3.up * castHeight;

        if (escapeCooldown > 0f) escapeCooldown -= Time.fixedDeltaTime;

        float moved = (pos - lastPos).magnitude;
        lastPos = pos;

        if (moved < stuckThreshold) stuckTimer += Time.fixedDeltaTime;
        else stuckTimer = 0f;

        if (escapeTimer > 0f)
        {
            escapeTimer -= Time.fixedDeltaTime;
            Move(escapeDir);
            return;
        }

        bool Blocked(Vector3 dir)
        {
            dir.y = 0f;
            if (dir.sqrMagnitude < 0.0001f) return true;

            return Physics.SphereCast(
                origin,
                castRadius,
                dir.normalized,
                out _,
                checkDistance,
                obstacleMask,
                QueryTriggerInteraction.Ignore
            );
        }

        if (!Blocked(desiredDir))
        {
            Move(desiredDir);
            return;
        }

        Vector3 leftDir = Quaternion.Euler(0f, -avoidAngle, 0f) * desiredDir;
        Vector3 rightDir = Quaternion.Euler(0f, avoidAngle, 0f) * desiredDir;

        bool leftBlocked = Blocked(leftDir);
        bool rightBlocked = Blocked(rightDir);

        if (!leftBlocked && rightBlocked)
        {
            Move(leftDir);
            return;
        }

        if (!rightBlocked && leftBlocked)
        {
            Move(rightDir);
            return;
        }

        if (!leftBlocked && !rightBlocked)
        {
            float l = Vector3.Dot(leftDir.normalized, desiredDir);
            float r = Vector3.Dot(rightDir.normalized, desiredDir);
            Move(l > r ? leftDir : rightDir);
            return;
        }

        if (stuckTimer < stuckTimeToEscape || escapeCooldown > 0f)
        {
            Quaternion turn = Quaternion.Euler(0f, 60f * Time.fixedDeltaTime, 0f);
            Move(turn * desiredDir);
            return;
        }

        escapeCooldown = escapeCooldownTime;
        stuckTimer = 0f;

        Vector3 backDir = -desiredDir;

        Vector3 escapeLeft = Quaternion.Euler(0f, -90f, 0f) * desiredDir;
        Vector3 escapeRight = Quaternion.Euler(0f, 90f, 0f) * desiredDir;

        bool canLeft = !Blocked(escapeLeft);
        bool canRight = !Blocked(escapeRight);

        if (canLeft && !canRight)
            escapeDir = escapeLeft.normalized;
        else if (canRight && !canLeft)
            escapeDir = escapeRight.normalized;
        else
            escapeDir = escapeRight.normalized;

        escapeTimer = escapeDuration;
        Vector3 newPos = rb.position + backDir * stuckBackUpSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);

        Quaternion targetRot = Quaternion.LookRotation(escapeDir, Vector3.up);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime));
    }

    private void Move(Vector3 dir)
    {
        dir.y = 0f;
        dir.Normalize();

        Vector3 newPos = rb.position + dir * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);

        if (dir.sqrMagnitude > 0.0001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime));
        }
    }
}
