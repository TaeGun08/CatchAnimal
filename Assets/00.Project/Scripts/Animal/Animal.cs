using UnityEngine;

public class Animal : MonoBehaviour
{
    [Header("Rinding Transform")]
    [SerializeField] private Vector3 ridingOffset;
    
    public void Riding(Player player)
    {
        player.transform.parent = transform;
        player.transform.localPosition = ridingOffset;
    }
}
