using UnityEngine;

public class Coin : MonoBehaviour
{
    // Moves the coin
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = -transform.right * 5f;
        if (transform.position.x <= -8) Destroy(this.gameObject);
    }
}
