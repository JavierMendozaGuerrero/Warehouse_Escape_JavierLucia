using UnityEngine;

public class ChaseState : IRobotState
{
    public void Enter(GuardRobot robot) { }
    public void Exit(GuardRobot robot) { }

    public void Update(GuardRobot robot)
    {
        if (robot.thief == null) return;

        robot.MoveToAvoiding(robot.thief.position);


        float dist = Vector3.Distance(robot.transform.position, robot.thief.position);
        if (dist < 1.5f)
        {
            Debug.Log(">>> CAPTURE CONDITION TRUE (dist<0.8)");
            Thief t = robot.thief.GetComponent<Thief>();
            if (t != null) t.CaughtByGuard();
            else Debug.LogError("Thief component NOT found on robot.thief");
        }
    }
}

