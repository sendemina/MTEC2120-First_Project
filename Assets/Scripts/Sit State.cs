using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitState : IState
{
    public void OnEnter(StateController controller)
    {
        controller.animator.SetTrigger("Sitting");
    }

    public void UpdateState(StateController controller) { }

    public void OnExit(StateController controller) { }
}
