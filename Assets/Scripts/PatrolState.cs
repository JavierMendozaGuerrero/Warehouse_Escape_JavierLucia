using UnityEngine;

public class PatrolState : IRobotState
{
    private int idx = 0;
    private const float arriveDist = 1.2f;

    private Vector3 lastPos;
    private float stuckTimer = 0f;
    private const float maxStuckTime = 1.5f;

    public void Enter(GuardRobot robot)
    {
        if (robot.waypoints == null || robot.waypoints.Length == 0)
        {
            return;
        }

        idx = 0;
        float best = float.PositiveInfinity;
        Vector3 pos = robot.transform.position;

        for (int i = 0; i < robot.waypoints.Length; i++)
        {
            Transform wp = robot.waypoints[i];
            if (wp == null) continue;

            Vector3 d = wp.position - pos;
            d.y = 0f;
            float s = d.sqrMagnitude;

            if (s < best)
            {
                best = s;
                idx = i;
            }
        }

        lastPos = robot.transform.position;
        stuckTimer = 0f;
    }

    public void Update(GuardRobot robot)
    {
        if (robot.waypoints == null || robot.waypoints.Length == 0) return;

        if (robot.waypoints[idx] == null)
        {
            idx = (idx + 1) % robot.waypoints.Length;
            return;
        }

        Vector3 pos = robot.transform.position;
        Vector3 target = robot.waypoints[idx].position;
        target.y = pos.y;

        robot.MoveToAvoiding(target);

        Vector3 diff = target - pos;
        diff.y = 0f;

        if (diff.sqrMagnitude < arriveDist * arriveDist)
        {
            idx = (idx + 1) % robot.waypoints.Length;
            stuckTimer = 0f;
            lastPos = pos;
            return;
        }


        float moved = (pos - lastPos).magnitude;
        lastPos = pos;

        float dt = Time.fixedDeltaTime > 0f ? Time.fixedDeltaTime : Time.deltaTime;

        if (moved < 0.05f) stuckTimer += dt;
        else stuckTimer = 0f;

        if (stuckTimer > maxStuckTime)
        {
            idx = (idx + 1) % robot.waypoints.Length;
            stuckTimer = 0f;
        }
    }

    public void Exit(GuardRobot robot) { }
}

