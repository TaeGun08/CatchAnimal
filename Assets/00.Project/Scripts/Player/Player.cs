using UnityEngine;

public class Player : SingletonBehavior<Player>
{
    private Animator animator;

    public void ChangeAnimation(string animation)
    {
        animator.SetTrigger(animation);
    }
}
