using UnityEngine;

public abstract class AutoBehavior : MonoBehaviour
{
    public AnimalContext Context { get; set; }

    public virtual void Initialize(AnimalContext context)
    {
        Context = context;
    }

    protected void FixedUpdate()
    {
        Behavior();
    }
    
    public virtual void Behavior(){}
}
