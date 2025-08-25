using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimalContext
{
    public AnimalController Controller { get; set; }
    public Animator Animator { get; set; }
    public Rigidbody Rigidbody { get; set; }
    public AnimalStatus AnimalStatus { get; set; }
}

public class AnimalController : MonoBehaviour
{
    private AnimalState currentState;
    private AnimalState[] states;

    [Header("Animator")]
    [SerializeField] private Animator animator;
    
    private void Awake()
    {
        var context = new AnimalContext()
        {
            Controller = this,
            Animator = animator,
            Rigidbody = GetComponent<Rigidbody>(),
            AnimalStatus = GetComponent<AnimalStatus>(),
        };
        
        states = GetComponentsInChildren<AnimalState>();

        foreach (var state in states)
        {
            state.Initialize(context);
        }
        
        currentState = states[0];
        currentState?.StateEnter();
    }

    public void ChangeState<T>() where T : AnimalState
    {
        if (enabled == false) return;

        currentState?.StateExit();
        currentState = states.FirstOrDefault(state => state is T);
        
        if (currentState == null) currentState = states[0];
        
        currentState?.StateEnter();
    }
}
