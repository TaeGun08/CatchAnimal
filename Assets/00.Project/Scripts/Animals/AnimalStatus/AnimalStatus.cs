using UnityEngine;

public class AnimalStatus : MonoBehaviour
{
    [Header("Status")] 
    [field: SerializeField] private float Gravity { get; set; }
    [field: SerializeField] public float MoveSpeed { get; set; }
    [field: SerializeField] private float JumpForce { get; set; }
}
