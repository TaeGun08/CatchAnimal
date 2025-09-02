using UnityEngine;

public class AnimalAutoStateBase : AnimalStateBase
{
    private AutoBehavior autoBehavior;
    
    public override void Initialize(AnimalContext context)
    {
        base.Initialize(context);
        
        if (autoBehavior == null)
        {
            autoBehavior = GetComponent<AutoBehavior>();
        }
        
        autoBehavior.Initialize(context);
    }
    
    public override void StateEnter()
    {
        autoBehavior.enabled = true;
    }

    public override void StateExit()
    {
        autoBehavior.enabled = false;
    }
}
