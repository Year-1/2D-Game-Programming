using UnityEngine;

// Tags objects with these ID's
public enum Collisions
{
    ENEMY,
    FINISH_LINE,
    COIN,
    SPIKE
}
public class Enum : MonoBehaviour
{
    public Collisions collisions;
}
