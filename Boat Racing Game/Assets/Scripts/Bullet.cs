using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Holds the map bounds.
    Boundary boundary = new Boundary(true);

    public Player1 playerOneScript;
    public Player2 playerTwoScript;

    public float movement;

    public bool playerShot = false;
    public bool bossShot = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerShotTrigger(collision);
        BossShotTrigger(collision);
    }

    void FixedUpdate()
    {
        Move();
    }

    //Generates a random number between 0-19.
    int RandomNumberGen()
    {
        int a = Random.Range(0, 20);
        return a;
    }

    // Moves the bullet and destroys is depending on position.
    public void Move()
    {
        transform.Translate(new Vector2(movement, 0));
        if (transform.position.x <= boundary.xMin) Destroy(this.gameObject);
        if (transform.position.x >= boundary.xMax) Destroy(this.gameObject);
        if (transform.position.y <= boundary.yMin) Destroy(this.gameObject);
        if (transform.position.y >= boundary.yMax) Destroy(this.gameObject);
    }

    //Gets which object fires the bullet then assigns the script to a variable.
    public void PlayerShot(GameObject playerName)
    {
        if (playerName.CompareTag("Player1")) {
            playerOneScript = playerName.GetComponent<Player1>();
        }

        if (playerName.CompareTag("Player2")) {
            playerTwoScript = playerName.GetComponent<Player2>();
        }
        playerShot = true;
    }

    // Checks if the player shot, then destroys the bullet and adds score to player.
    public void PlayerShotTrigger(Collider2D collision)
    {
        if (playerShot) {
            if (collision.CompareTag("Enemy")) {
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                if (playerOneScript != null) {
                    playerOneScript.GainScore(50);

                    if (RandomNumberGen() == 18) {
                        playerOneScript.GainLife(1);
                    }
                    if (RandomNumberGen() == 19) {
                        playerOneScript.GainHealth();
                    }
                }
                if (playerTwoScript != null) {
                    playerTwoScript.GainScore(50);
                    if (RandomNumberGen() == 18) {
                        playerTwoScript.GainLife(1);
                    }
                    if (RandomNumberGen() == 19) {
                        playerTwoScript.GainHealth();
                    }
                }
            }

            if (collision.CompareTag("Boss")) {
                if (playerOneScript != null) {
                    playerOneScript.GainScore(25);
                    collision.GetComponent<Boss>().LoseHealth(10, "Player1");
                }
                if (playerTwoScript != null) {
                    playerTwoScript.GainScore(25);
                    collision.GetComponent<Boss>().LoseHealth(10, "Player2");
                }

                Destroy(this.gameObject);
            }
        }
    }

    // When the boss shoots sets this to true so the boss bullets can be tracked
    public void BossShot()
    {
        bossShot = true;
    }

    // If the boss shot and the bullet hits the player, damage them.
    public void BossShotTrigger(Collider2D collision)
    {
        if (bossShot) {
            if (collision.CompareTag("Player1")) {
                playerOneScript = collision.GetComponent<Player1>();
                playerOneScript.LoseHealth(25);
                Destroy(this.gameObject);
            }
            if (collision.CompareTag("Player2")) {
                playerTwoScript = collision.GetComponent<Player2>();
                playerTwoScript.LoseHealth(25);
                Destroy(this.gameObject);
            }
        }
    }

    // Sets the movement so the boss can share the bullet logic
    public void SetMovement(float MOVEMENT)
    {
        movement = MOVEMENT;
    }
}
