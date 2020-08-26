using UnityEngine;

public class FinishLineMove : MonoBehaviour
{
    //Moves the finish line left.
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = -transform.right * 3f;
    }
}
