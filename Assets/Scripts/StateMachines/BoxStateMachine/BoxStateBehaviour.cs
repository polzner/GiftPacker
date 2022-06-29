using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BoxStateBehaviour : MonoBehaviour, IStateSwitcher
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private BezierMover _startMover;
    [SerializeField] private BezierMover _endMover;
    [SerializeField] private Animator _boxAnimator;
    [SerializeField] private Animator _characterMovingAnimator;
    [SerializeField] private Animation _congragulationAnimation;
    [SerializeField] private ParticleSystem _starsEffect;
    [SerializeField] private BoxTriggerSideAnimationPlayer _boxSideAnimationPlayer;
    [SerializeField] private BoxModelChanger _boxRandomizer;
    [SerializeField] private BoxFillerPlacer _boxFillerPlacer;
    [SerializeField] private Toy _toy;
    [SerializeField] private RigRecoverer _handRigRecoverer;
    [SerializeField] private PackingReseter _packingReseter;
    [SerializeField] private BowPlacer _bowPlacer;
    [SerializeField] private float _switchDelay = 2;

    private List<BaseState> _allStates;
    private BaseState _currentState;

    private void Awake()
    {
        _allStates = new List<BaseState>()
        {
            new StartState(_boxAnimator, this, _packingReseter, _startMover),
            new StartPackingBoxState(_boxAnimator, this, _boxRandomizer, _boxSideAnimationPlayer,
            _characterMovingAnimator, _handRigRecoverer),
            new EndPackingBoxState(_boxAnimator, this, _boxRandomizer, _boxSideAnimationPlayer),
            new FillerPlaceState(_boxAnimator, this, _boxRandomizer, _toy, _switchDelay, _boxFillerPlacer),
            new BowPlaceState(_boxAnimator, this, _starsEffect, _bowPlacer, _boxRandomizer, _congragulationAnimation),
            new PackedBoxState(_boxAnimator, this, _handRigRecoverer, _boxRandomizer),
            new EndState(_boxAnimator, this, _characterMovingAnimator, _endMover)
        };

        _currentState = _allStates[0];
    }

    private void Start()
    {
        _currentState.Start();
    }

    private void OnEnable()
    {
        foreach (BaseState state in _allStates)
        {
            if (state is IAvailability)
            {
                ((IAvailability)state).OnEnable();
            }
        }

        _input.LeftSideClicked += OnLeftSideClicked;
        _input.RightSideClicked += OnRightSideClicked;
    }

    private void OnDisable()
    {
        foreach (BaseState state in _allStates)
        {
            if (state is IAvailability)
            {
                ((IAvailability)state).OnDisable();
            }
        }

        _input.LeftSideClicked -= OnLeftSideClicked;
        _input.RightSideClicked -= OnRightSideClicked;
    }

    private void OnLeftSideClicked()
    {
        if (_currentState is IClickable)
        {
            ((IClickable)_currentState).OnLeftSideClicked();
        }
    }

    private void OnRightSideClicked()
    {
        if (_currentState is IClickable)
        {
            ((IClickable)_currentState).OnRightSideClicked();
        }
    }

    public void Switch<T>() where T : BaseState
    {
        MoveNextState<T>();
    }

    public void Switch<T>(float delay) where T : BaseState
    {
        StartCoroutine(SwitchRoutine<T>(delay));
    }

    private IEnumerator SwitchRoutine<T>(float delay) where T : BaseState
    {
        yield return new WaitForSeconds(delay);
        MoveNextState<T>();
    }

    private void MoveNextState<T>() where T : BaseState
    {
        BaseState state = _allStates.FirstOrDefault(state => state is T);
        _currentState.Stop();
        _currentState = state;
        _currentState.Start();
    }
}
