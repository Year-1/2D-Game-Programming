using UnityEngine;

public class SimpleEnemy : Enemy
{
    // Moves the simple enemy left and when x is lower than -8 destroys the object.
    void Update()
    {
        Move();
    }

    // Moves the simple enemy.
    public override void Move()
    {
        GetComponent<Rigidbody2D>().velocity = -transform.right * 3f;
        if (transform.position.x <= -8) Destroy(this.gameObject);
    }
}
