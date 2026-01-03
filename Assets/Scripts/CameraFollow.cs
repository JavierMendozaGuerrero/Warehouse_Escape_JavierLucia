using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 10f, -5f);
    [SerializeField] private Vector3 eulerRotation = new Vector3(45f, 0f, 0f);


    private void LateUpdate()
    {
        if (target == null) return;

        transform.position = target.position + offset;
        transform.rotation = Quaternion.Euler(eulerRotation);
    }
}
