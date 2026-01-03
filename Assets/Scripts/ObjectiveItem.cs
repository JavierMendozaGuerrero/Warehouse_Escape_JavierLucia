using UnityEngine;

public class ObjectiveItem : MonoBehaviour
{
    private bool collected;

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;
        if (!other.CompareTag("Player")) return;

        collected = true;

        FindFirstObjectByType<GameManager>()?.OnObjectiveCollected();
        FindFirstObjectByType<ExitSpawner>()?.ActivateExit();
        ScoreManager.Instance?.AddScore(100);

        Destroy(gameObject);
    }
}
