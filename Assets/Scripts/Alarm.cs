using UnityEngine;

public class Alarm : MonoBehaviour
{
    private GuardRobot[] guards;
    private bool triggered = false;

    
    public void Init(GuardRobot[] guardsToNotify)
    {
        guards = guardsToNotify;
    }

    private void OnTriggerEnter(Collider other)
    {


        if (!other.CompareTag("Player")) return;


        if (triggered) return;
        triggered = true;

        if (guards == null || guards.Length == 0)
        {
            return;
        }

        Vector3 alarmPos = transform.position;
        foreach (var g in guards)
        {
            if (g != null)
                g.OnAlarm(alarmPos);
        }
    }

}
