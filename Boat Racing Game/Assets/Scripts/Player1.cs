using UnityEngine;

public class Player1 : Character
{
    //Assigns the unity project input for player 1.
    private protected const string PLAYER_ONE_HORIZONTAL = "HorizontalOne";
    private protected const string PLAYER_ONE_VERTICAL = "VerticalOne";
    private protected const string PLAYER_ONE_FIRE = "Fire1";

    public GameObject turret;
    public GameObject bullet;

    public GameObject finishLine;

    public UI userInterface;

    private void Start()
    {
        lives = 3;
        speed = 5;
        health = 100;
        coins = 0;
        score = 0;
        timer = 0.0f;

        Player1FinishLine = finishLine;

        SetPlayer(this.gameObject);
        SetUI(userInterface);
    }

    public void FixedUpdate()
    {
        //passes the parameters to the parents move method.
        Move(speed, PLAYER_ONE_VERTICAL, PLAYER_ONE_HORIZONTAL);
        //Calls a method from the parent class with the parameters of bullet and location of shot
        Shoot(bullet, turret.transform.position, PLAYER_ONE_FIRE, this.gameObject);
    }
}
