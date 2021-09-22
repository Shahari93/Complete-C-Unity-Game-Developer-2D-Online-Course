using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private float xMin, xMax, yMin, yMax;


    private void Start()
    {
        SetUpBoundries();
    }

    private void SetUpBoundries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0.078f, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(0.92f, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.038f, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.85f, 0)).y;
    }

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize(); // normalize so movement on x & y axis will be at the same speed
        movement *= Time.deltaTime * movementSpeed;

        float xClamp = Mathf.Clamp(movement.x + transform.position.x, xMin, xMax);
        float yClamp = Mathf.Clamp(movement.y + transform.position.y, yMin, yMax);

        transform.position = new Vector2(xClamp, yClamp);
    }
}