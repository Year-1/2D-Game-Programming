using UnityEngine;

public class Boss : MonoBehaviour
{
    Boundary boundary = new Boundary(true);
    public Vector3 targetPos;

    public GameObject bullet;
    public Transform turretPos;

    public int health;

    public float nextFire;
    public float fireRate = 5f;

    Player1 p1Script;
    Player2 p2Script;

    // Get a reference to both players upon start
    void Start()
    {
        targetPos = new Vector3(6, -2, 0);
        health = 100;

        if (GameObject.FindGameObjectWithTag("Player1")) {
            p1Script = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1>();
        }
        if (GameObject.FindGameObjectWithTag("Player2")) {
            p2Script = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2>();
        }
    }

    void FixedUpdate()
    {
        Move();
        Shoot();
    }

    // Moves the boss on screen
    public void Move()
    {
        transform.Translate(new Vector2(-.1f, 0));
        if (transform.position.x <= 6) {
            transform.position = targetPos;
        }
        if (transform.position.x <= boundary.xMin) Destroy(this.gameObject);
        if (transform.position.x >= 15) Destroy(this.gameObject);
        if (transform.position.y <= boundary.yMin) Destroy(this.gameObject);
        if (transform.position.y >= boundary.yMax) Destroy(this.gameObject);
    }

    // Shoots a bullet
    public void Shoot()
    {
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            int[] spawnRotation = { -30, 0, 30 };
            GameObject[] bulletGO = new GameObject[3];

            for (int i = 0; i < 3; i++) {
                bulletGO[i] = Instantiate(bullet, turretPos.position, Quaternion.Euler(0, 0, spawnRotation[i]));
                bulletGO[i].GetComponent<Bullet>().SetMovement(-.1f);
                bulletGO[i].GetComponent<Bullet>().BossShot();
            }
        }
    }

    // Gives the player that shot it dead points
    public void Die(string playerReward)
    {
        if (playerReward == "Player1") {
            p1Script.GainScore(1000);
        }
        if (playerReward == "Player2") {
            p2Script.GainScore(1000);
        }
    }

    // Lose health when the player shoots
    public void LoseHealth(int damageAmount, string player)
    {
        health -= damageAmount;
        if (health <= 0) {
            Destroy(this.gameObject);
            Die(player);
        }
    }
}
