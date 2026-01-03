using UnityEngine;

public class ExitSpawner : MonoBehaviour
{
    [SerializeField] private ExitZone exitPrefab;

    [Header("Suelo (BG)")]
    [SerializeField] private LayerMask groundMask;     
    [SerializeField] private float raycastHeight = 50f;

    [Header("Puerta")]
    [SerializeField] private float doorHalfHeight = 2.5f; 

    private readonly Vector3[] exitPositions =
    {
        new Vector3(  5f, 0f, -15f),
        new Vector3( 10f, 0f, -10f),
        new Vector3( 10f, 0f,   0f),
        new Vector3( 10f, 0f,  10f),
        new Vector3(  5f, 0f,  15f),
        new Vector3( -5f, 0f,  15f),
        new Vector3(-10f, 0f,  10f),
        new Vector3(-10f, 0f,   0f),
        new Vector3(-10f, 0f, -10f),
        new Vector3( -5f, 0f, -15f)
    };

    private ExitZone spawnedExit;

    private void Start()
    {
        if (exitPrefab == null)
        {
            return;
        }

        int idx = Random.Range(0, exitPositions.Length);
        Vector3 pos = exitPositions[idx];

        bool isHorizontal = IsHorizontal(pos);
        float yRotation = isHorizontal ? 0f : 90f;

        Vector3 rayOrigin = new Vector3(pos.x, raycastHeight, pos.z);

        if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, raycastHeight * 2f, groundMask))
        {
            pos.y = hit.point.y + doorHalfHeight;
        }
        else
        {
            pos.y = doorHalfHeight;
        }

        spawnedExit = Instantiate(exitPrefab, pos, Quaternion.Euler(0f, yRotation, 0f));
        spawnedExit.Activate(false);
    }

    private bool IsHorizontal(Vector3 pos)
    {
        return IsEdgeValue(pos.x) || IsEdgeValue(pos.z);
    }

    private bool IsEdgeValue(float v)
    {
        return Mathf.Approximately(v, -5f) ||
               Mathf.Approximately(v, 5f) ||
               Mathf.Approximately(v, 15f) ||
               Mathf.Approximately(v, -15f);
    }

    public void ActivateExit()
    {
        if (spawnedExit != null)
            spawnedExit.Activate(true);
    }
}
