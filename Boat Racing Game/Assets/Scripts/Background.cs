using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject background;
    public GameObject foreground;

    //Moves the background images constantly, when a certain position is reached it resets.
    //Move background and moveforeground are basically the same.
    private void Update()
    {
        MoveObjects(-4, 0, -9.1f, background, new Vector3(9.1f, 0, 10));
        MoveObjects(-2, 0, -18f, foreground, new Vector3(0, 0, 9));
    }

    // Moves the object in the set direction until it reaches a condition then it resets its position
    public void MoveObjects(int xTranslate, int yTranslate, float condition, GameObject objectToMove, Vector3 resetPosition)
    {
        float xMove = xTranslate;
        float yMove = yTranslate;

        if (objectToMove.transform.position.x < condition) {
            objectToMove.transform.position = resetPosition;
            objectToMove.SetActive(true);
        } else {
            objectToMove.transform.Translate(new Vector2(xMove, yMove) * Time.deltaTime);
        }

    }
}
