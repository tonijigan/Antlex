using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] protected EnemyState EnemyState;

    public abstract void Condition();
}