using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface RestContext
{
    void SetState(RestState restState);
}

public interface RestState
{
    void Stand(RestContext context);
    void Sit(RestContext context);
    void Sleep(RestContext context);
}

public class RestStatePattern : MonoBehaviour, RestContext
{
    RestState currentState;

    public void Stand() => currentState.Stand(this);
    public void Sit() => currentState.Sit(this);
    public void Sleep() => currentState.Sleep(this);

    void RestContext.SetState(RestState newState)
    {
        currentState = newState;
    }

}

public class StandingState : RestState
{
    public void Stand(RestContext context) { }

    public void Sit(RestContext context)
    {
        context.SetState(new SittingState());
    }

    public void Sleep(RestContext context)
    {
        context.SetState(new SleepingState());
    }
}

public class SittingState : RestState
{
    public void Stand(RestContext context)
    {
        context.SetState(new StandingState());
    }

    public void Sit(RestContext context) { }

    public void Sleep(RestContext context)
    {
        context.SetState(new SleepingState());
    }
}

public class SleepingState : RestState
{
    public void Stand(RestContext context)
    {
        context.SetState(new StandingState());
    }

    public void Sit(RestContext context)
    {
        context.SetState(new SittingState());
    }

    public void Sleep(RestContext context) { }
}