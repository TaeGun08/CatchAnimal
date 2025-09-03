using UnityEngine;

public class AnimalDeadState : AnimalStateBase
{
    private static readonly int Dead = Animator.StringToHash("Dead");

    public override void StateEnter()
    {
        foreach (var animator in Animators)
        {
            animator.SetTrigger(Dead);
        }
    }

    public override void StateExit()
    {
    }
}
