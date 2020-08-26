using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float xMove, yMove;
    public int noOfBounces;

    // Holds the map bounds
    Boundary boundary = new Boundary(true);

    private void Start()
    {
        xMove = 0.1f;
        yMove = 0.1f;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public virtual void Move()
    {
        //When the ball has bounced 10 times destroy it 
        if (noOfBounces >= 10) Destroy(this.gameObject);

        //If the position is at the bound inverse its movement.
        if (transform.position.x >= boundary.xMax || transform.position.x <= boundary.xMin) {
            xMove *= -1;
            noOfBounces++;
        }
        if (transform.position.y >= boundary.yMax || transform.position.y <= boundary.yMin) {
            yMove *= -1;
            noOfBounces++;
        }
        //Moves the object with the given parameters.
        transform.Translate(new Vector2(xMove, yMove));
    }
}
