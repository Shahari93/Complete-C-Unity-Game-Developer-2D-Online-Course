using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Config parm")]
    [SerializeField] Paddle paddle = null;
    [SerializeField] Rigidbody2D ballRB = null;
    [SerializeField] float speed = 3f;
    [SerializeField] float xVelocity;
    [SerializeField] float yVelocity = 15f;
    private Vector2 paddleToBallVector;

    private bool isGameStarted = false;
    private int timesMouseWasPressed = 0;

    private void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        CalcRandomXVelocity();
    }


    private void Update()
    {
        LockBallToPaddle();
        LaunchBallAtMouseClick();
    }

    private void LockBallToPaddle()
    {
        if (!isGameStarted)
        {
            Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
        }
    }

    private void LaunchBallAtMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && timesMouseWasPressed == 0)
        {
            timesMouseWasPressed++;
            isGameStarted = true;
            ballRB.simulated = true;
            ballRB.velocity += new Vector2(xVelocity, yVelocity);
        }
    }

    private void CalcRandomXVelocity()
    {
        xVelocity = Random.Range(-5f, 8f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play(); // get component works only on game objects that have this class
    }
}
// TODO: Need to set simulated variable to true when launching the ball