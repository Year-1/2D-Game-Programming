using UnityEngine;

public class Spike : MonoBehaviour
{
    Boundary boundary = new Boundary(true);

    private float y;

    void Start()
    {
        y = transform.position.y;
    }

    void FixedUpdate()
    {
        Move();
    }

    // Moves the spike and checks its bounds.
    public void Move()
    {
        transform.Translate(new Vector2(-0.1f, 0));
        if (transform.position.x <= boundary.xMin) Destroy(this.gameObject);
        if (transform.position.x >= boundary.xMax + 5) Destroy(this.gameObject);
        if (transform.position.y <= boundary.yMin - 2) Destroy(this.gameObject);
        if (transform.position.y >= boundary.yMax + 2) Destroy(this.gameObject);
    }
}
