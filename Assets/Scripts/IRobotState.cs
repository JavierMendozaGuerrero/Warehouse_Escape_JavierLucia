using UnityEngine;

public interface IRobotState

{
    void Enter(GuardRobot robot);
    void Update(GuardRobot robot);
    void Exit(GuardRobot robot);
}

