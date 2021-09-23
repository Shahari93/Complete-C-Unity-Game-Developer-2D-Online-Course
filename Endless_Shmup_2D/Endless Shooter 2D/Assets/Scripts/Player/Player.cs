using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private bool phone = true; // Remove when mobile
    [SerializeField] private float movementSpeed; // Remove when mobile
    private float deltaX, deltaY;
    private Rigidbody2D playerRB;
    Camera mainCam;
    private float xMin, xMax, yMin, yMax; // Remove when mobile

    private void Start()
    {
        mainCam = Camera.main;
        playerRB = GetComponent<Rigidbody2D>();

        // Remove when mobile
        SetUpBoundries();
    }

    // Remove when mobile
    private void SetUpBoundries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (phone)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPos = mainCam.ScreenToWorldPoint(touch.position);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        break;
                    case TouchPhase.Moved:
                        playerRB.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                        break;
                    case TouchPhase.Ended:
                        playerRB.velocity = Vector2.zero;
                        break;
                }
            }
        }
        // Remove when mobile
        else
        {
            Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            movement.Normalize(); // normalize so movement on x & y axis will be at the same speed
            movement *= Time.deltaTime * movementSpeed;

            float xClamp = Mathf.Clamp(movement.x + transform.position.x, xMin, xMax);
            float yClamp = Mathf.Clamp(movement.y + transform.position.y, yMin, yMax);

            transform.position = new Vector2(xClamp, yClamp);
        }
    }
}

//[SerializeField] private float movementSpeed;
//private float xMin, xMax, yMin, yMax;

//private void Start()
//{
//    SetUpBoundries();
//}

//private void SetUpBoundries()
//{
//    Camera gameCamera = Camera.main;
//    xMin = gameCamera.ViewportToWorldPoint(new Vector3(0.078f, 0, 0)).x;
//    xMax = gameCamera.ViewportToWorldPoint(new Vector3(0.92f, 0, 0)).x;
//    yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.038f, 0)).y;
//    yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.85f, 0)).y;
//}

//void Update()
//{
//    PlayerMovement();
//}

//private void PlayerMovement()
//{
//    Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
//    movement.Normalize(); // normalize so movement on x & y axis will be at the same speed
//    movement *= Time.deltaTime * movementSpeed;

//    float xClamp = Mathf.Clamp(movement.x + transform.position.x, xMin, xMax);
//    float yClamp = Mathf.Clamp(movement.y + transform.position.y, yMin, yMax);

//    transform.position = new Vector2(xClamp, yClamp);
//}