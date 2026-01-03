using UnityEngine;

public class StateMachine
{
    private IRobotState currentState;
    private GuardRobot robot;

    public StateMachine(GuardRobot robot)
    {
        this.robot = robot;
    }

    public void SetState(IRobotState newState)
    {
        if (currentState != null) 
            currentState.Exit(robot);
        currentState = newState;
        if (currentState != null) 
            currentState.Enter(robot);
    }

    public void Update()
    {
        if (currentState != null) 
            currentState.Update(robot);
    }
}

