using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Config parm")]
    [SerializeField] float xVelocity;
    [SerializeField] float yVelocity = 15f;
    [SerializeField] private Paddle paddle;
    private Vector2 paddleToBallVector;

    [SerializeField] AudioClip[] ballSounds; // created an array of audio clips
    private AudioSource audioSource;
    private Rigidbody2D ballRB;


    private bool isGameStarted = false;
    private int timesMouseWasPressed = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ballRB = GetComponent<Rigidbody2D>();
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
        if (isGameStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length - 1)];
            audioSource.PlayOneShot(clip); // get component works only on game objects that have this class
        }
    }
}
// TODO: Need to set simulated variable to true when launching the ball