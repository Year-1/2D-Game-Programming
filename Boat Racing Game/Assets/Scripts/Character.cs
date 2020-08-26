using UnityEngine;

// Holds the map bounds

[System.Serializable]
public struct Boundary
{
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public Boundary(bool placeholder)
    {
        xMin = -8f;
        xMax = 8f;
        yMin = -4f;
        yMax = 2f;
    }
}

public class Character : MonoBehaviour
{
    //Uncomment the save and load commands,

    Boundary boundary = new Boundary(true);
    public UI UserInterface;

    public Vector2 tempVec2 = new Vector2(8f, -1f);

    public GameObject player1FinishLine;
    public GameObject player2FinishLine;

    // Used to assign the finish line for the player
    public GameObject Player1FinishLine { get { return player1FinishLine; } set { player1FinishLine = value; } }
    public GameObject Player2FinishLine { get { return player2FinishLine; } set { player2FinishLine = value; } }

    public int lives;
    public int health;
    public int score;

    public int GetScore { get { return score; } }
    public int speed;

    public int coins;
    public int GetCoins { get { return coins; } }

    public float timer;
    public int seconds, minutes;
    float nextFire;
    float fireRate = 0.25f;

    GameObject player;

    // Checks collisions and performs a method if collidiingwith certain gameobjects.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Inspired and synergised from personal tutoring sessions by Carlo.
        Enum collisionType = collision.gameObject.GetComponent<Enum>();
        if (collisionType != null) {
            switch (collisionType.collisions) {

                case Collisions.ENEMY:
                    LoseHealth(50);
                    Destroy(collision.gameObject);
                    break;

                case Collisions.SPIKE:
                    LoseHealth(100);
                    Destroy(collision.gameObject);
                    break;

                case Collisions.FINISH_LINE:
                    Die();
                    break;

                case Collisions.COIN:
                    Coins(1);
                    Destroy(collision.gameObject);
                    break;
            }
        }
    }

    private void Update()
    {
        Timer();
    }

    // Gets given the parameters then moves or rotated the player accordingly.
    public void Move(int Speed, string vertCall, string horizCall)
    {
        float moveVertical = Input.GetAxis(vertCall);
        float moveHorizontal = Input.GetAxis(horizCall);

        // Rotating the player.
        transform.Rotate(0, 0, -moveVertical * Speed);

        // Moving the player.
        Vector3 tempPhys = new Vector3(-0.05f, 0, 0);
        Vector3 tempPlayerMove = new Vector3(moveHorizontal * Speed * Time.deltaTime, 0, 0);

        transform.Translate(tempPhys + tempPlayerMove);

        // Checks the players rotation and sets the rotation to the bounds.
        if (transform.rotation.z >= 0.65f) {
            transform.rotation = Quaternion.Euler(0, 0, 80);
        }
        if (transform.rotation.z <= -0.65f) {
            transform.rotation = Quaternion.Euler(0, 0, -80);
        }

        // Checks the players position against the bounds and sets the player position to the bounds.
        if (transform.position.x <= boundary.xMin) {
            transform.position = new Vector2(boundary.xMin, transform.position.y);
        }
        if (transform.position.x >= boundary.xMax) {
            transform.position = new Vector2(boundary.xMax, transform.position.y);
        }
        if (transform.position.y <= boundary.yMin) {
            transform.position = new Vector2(transform.position.x, boundary.yMin);
        }
        if (transform.position.y >= boundary.yMax) {
            transform.position = new Vector2(transform.position.x, boundary.yMax);
        }
    }

    // Gets passed a bullet and position then instantiates it.
    public void Shoot(GameObject bullet, Vector3 vector, string input, GameObject player)
    {
        if (Input.GetAxis(input) != 0) {
            if (Time.time > nextFire) {
                nextFire = Time.time + fireRate;
                GameObject go = Instantiate(bullet, vector, transform.rotation) as GameObject;
                go.GetComponent<Bullet>().PlayerShot(player);
            }
        }
    }

    // Stops the game when the player runs out of lives and health and makes a button appear on screen.
    public void Die()
    {
        //if on 2 player dont save any scores
        SaveLoad.SL.Score = score;
        SaveLoad.SL.TotalCoins = coins;
        SaveLoad.SL.Save();
        Time.timeScale = 0f;
        UserInterface.ReturnToMainMenu();
    }

    // Checks if the player is dead if not, takes away 1 life and sets the health to 100. Then tells the ui to update with the new values.
    public void LoseLife(int livesLost)
    {
        if (lives <= 0) Die();
        else {
            lives--;
            health = 100;
            UserInterface.LoseLife(lives);
            UserInterface.Health(100);
        }
    }

    // Gain a life, if you have 3 restores the health. Then tells the ui to update.
    public void GainLife(int livesGained)
    {
        lives += livesGained;
        if (lives > 3) {
            lives = 3;
            health = 100;
            UserInterface.Health(health);
        }
        UserInterface.GainLife(lives);
    }

    // Gains the player health and then updates the UI.
    public void GainHealth()
    {
        health = 100;
        UserInterface.Health(health);
    }

    // Damage is passed in and then taken away from current health. Takes damage away from health and then updates the ui.
    // If the damage was more than the health call the lose Life method.
    public void LoseHealth(int damageAmount)
    {
        int livesLost = 1;
        health -= damageAmount;
        UserInterface.Health(health);
        if (health <= 0) {
            health = 0;
            UserInterface.Health(health);
            LoseLife(livesLost);
        }
    }

    // Increases the score by the parameter passed in. Passes the score to the ui.
    public void GainScore(int scoreAmount)
    {
        score += scoreAmount;
        UserInterface.Score(score);
    }

    // Displays the amount of coins on the screen.
    public void Coins(int amountOfCoins)
    {
        coins += amountOfCoins;
        UserInterface.Coins(coins);
    }

    // Counts the time and then converts it into minutes and seconds and passes it to the ui.
    public void Timer()
    {
        timer += Time.deltaTime;
        seconds = (int)timer;
        if (seconds >= 60) {
            timer = 0;
            minutes++;
        }
    }

    // Sets the player in the char class.
    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    // Sets the player to their UI.
    public void SetUI(UI playerUI)
    {
        UserInterface = playerUI;
    }
}
