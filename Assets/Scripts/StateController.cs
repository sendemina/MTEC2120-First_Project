using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IState
{
    public void OnEnter(StateController sc);
    public void UpdateState(StateController sc);
    public void OnExit(StateController sc);
}

[RequireComponent(typeof(PlayerInput))]
public class StateController : MonoBehaviour
{
    private IState currentState;

    private PlayerInput _playerInput;
    private Animator _animator;

    public Animator animator
    {
        get { return _animator; }
        set { _animator = value; }
    }

    private bool _hasAnimator;
    private int _animIDSit;
    private int _animIDSleep;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _hasAnimator = TryGetComponent(out _animator);
        AssignAnimationIDs();
        ChangeState(new StandState());
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        currentState.OnEnter(this);
    }

    private void AssignAnimationIDs()
    {
        _animIDSit = Animator.StringToHash("Sitting");
        _animIDSleep = Animator.StringToHash("Sleeping");
    }

    private void OnRest(InputValue value)
    {
         ChangeState(new SitState());
         _animator.SetBool(_animIDSit, true);

        //if (_animator.GetBool(_animIDSit)) //if is currently sitting
        //{
        //    _animator.SetBool(_animIDSleep, true);
        //}

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("SitLoop"))
        {
            _animator.SetBool(_animIDSleep, true);
        }
    }
}
