using UnityEngine;

public class ObjectiveSpawner : MonoBehaviour
{
    [SerializeField] private ObjectiveItem objectivePrefab;


    private Vector3[] basePositions =
    {
        new Vector3(-8.0f, 0f, -2.52f),  
        new Vector3(-7.28f, 0f,  6.76f),
        new Vector3(-1.35f, 0f,  7.06f),
        new Vector3( 3.76f, 0f, 10.61f),
        new Vector3( 8.0f,  0f,  3.36f),  
        new Vector3( 3.01f, 0f, -1.02f),
        new Vector3(-8.0f, 0f, -4.92f),  
        new Vector3(-4.65f, 0f, -9.97f),
        new Vector3( 6.90f, 0f, -10.80f),
        new Vector3( 1.10f, 0f, -13.0f),  
        new Vector3(-6.89f, 0f, -13.0f),  
        new Vector3( 7.56f, 0f, -13.0f)  
    };

    [Header("Rango de variación")]
    [SerializeField] private float offsetAmount = 1.5f;

    private const float MaxX = 8f;
    private const float MaxZ = 13f;

    private void Start()
    {
        SpawnObjective();
    }

    public void SpawnObjective()
    {

        if (objectivePrefab == null || basePositions.Length == 0)
        {
            return;
        }

        int idx = Random.Range(0, basePositions.Length);
        Vector3 pos = basePositions[idx];

        float offsetX = Random.Range(-offsetAmount, offsetAmount);
        float offsetZ = Random.Range(-offsetAmount, offsetAmount);

        pos.x += offsetX;
        pos.z += offsetZ;
        pos.y = 0f; 


        pos.x = Mathf.Clamp(pos.x, -MaxX, MaxX);
        pos.z = Mathf.Clamp(pos.z, -MaxZ, MaxZ);

        Debug.Log("[ObjectiveSpawner] Spawneando objetivo en " + pos + " (índice " + idx + ")");
        Instantiate(objectivePrefab, pos, Quaternion.identity);
    }
}
