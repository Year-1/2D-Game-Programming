using UnityEngine;

public class Player2 : Character
{
    //Assigns the unity project input for player 2.
    private protected const string PLAYER_TWO_HORIZONTAL = "HorizontalTwo";
    private protected const string PLAYER_TWO_VERTICAL = "VerticalTwo";
    private protected const string PLAYER_TWO_SHOOT = "Fire2";

    public GameObject turret;
    public GameObject bullet;

    public GameObject finishLine;

    public UI userInterface;

    private void Start()
    {
        lives = 3;
        speed = 5;
        health = 100;
        score = 0;
        coins = 0;
        timer = 0.0f;

        Player1FinishLine = finishLine;

        SetPlayer(this.gameObject);
        SetUI(userInterface);
    }

    public void FixedUpdate()
    {
        //Checks for inputs then passes the parameters to the parents move method.
        Move(speed, PLAYER_TWO_VERTICAL, PLAYER_TWO_HORIZONTAL);
        //Calls a method from the parent class with the parameters of bullet and location of shot
        Shoot(bullet, turret.transform.position, PLAYER_TWO_SHOOT, this.gameObject);
    }
}
