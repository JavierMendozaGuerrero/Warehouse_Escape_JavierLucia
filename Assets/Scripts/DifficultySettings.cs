using UnityEngine;

public enum Difficulty { Easy, Medium, Hard }

[CreateAssetMenu(menuName = "WarehouseEscape/Difficulty Settings")]
public class DifficultySettings : ScriptableObject
{
    public Difficulty difficulty;

    [Header("Alarmas")]
    public int alarmsCount = 3;

    [Header("Guardia")]
    public float guardMoveSpeed = 2.5f;
    public float guardRotationSpeed = 6f;

    [Header("Evitar obstáculos")]
    public float checkDistance = 1.2f;
    public float avoidAngle = 35f;
}
