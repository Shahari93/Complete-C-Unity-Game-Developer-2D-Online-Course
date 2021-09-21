using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("Configs parameters")]
    [SerializeField] private float screenWidthInWorldUnit = 16; // because we set the camera size to 6, the height is 12 and we have 4:3 ratio so the width is 16
    [SerializeField] private float screenXPosMin = 1f; // because we set the camera size to 6, the height is 12 and we have 4:3 ratio so the width is 16
    [SerializeField] private float screenXPosMax = 15f; // because we set the camera size to 6, the height is 12 and we have 4:3 ratio so the width is 16

    private GameStatus gameStatus;
    private Ball ball;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        MovePaddleWithMouse();
    }

    private void MovePaddleWithMouse()
    {
        //float mousePosInWorldUnit = Input.mousePosition.x / Screen.width * screenWidthInWorldUnit; // in order to convert the mouse position to world point we use this method 
                                                                                                   //(getting the mouse X pos, dividing by the screen width [Can be any screen size] and we multiply by the width world unit we set

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y); // setting the paddle position to the mouse pos variables
        paddlePos.x = Mathf.Clamp(GetXpos(), screenXPosMin, screenXPosMax); // clamping the paddle between 2 X position
        this.transform.position = paddlePos; // moving the paddle by the x axis, and by the X limit (clamp)
    }


    private float GetXpos()
    {
        if (gameStatus.IsAutoPlayEnabled())
        {
            return ball.gameObject.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInWorldUnit;
        }
    }
}