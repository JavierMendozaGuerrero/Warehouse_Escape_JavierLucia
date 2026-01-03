using UnityEngine;

public class ExitZone : MonoBehaviour
{
    [SerializeField] private bool isActive = false;

    public void Activate(bool active)
    {
        isActive = active;
        Collider c = GetComponent<Collider>();
        if (c != null) c.enabled = active;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"EXIT TRIGGER: entro {other.name} tag={other.tag} root={other.transform.root.name} rootTag={other.transform.root.tag} isActive={isActive}");
        if (!isActive) 
            return;
        if (!other.CompareTag("Player")) 
            return;

        GameManager gm = FindFirstObjectByType<GameManager>();
        if (gm == null || !gm.hasObjective) return;
        gm.OnThiefEscaped();

    }
}
