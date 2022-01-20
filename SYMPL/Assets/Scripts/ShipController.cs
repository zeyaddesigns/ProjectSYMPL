using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    
    public float forwardSpeed = 30f, strafeSpeed = 7.5f, hoverSpeed = 5f, boostSpeed = 10f, mouseFactor = 0.5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRotateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor. visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition();
        processMovement();
        processRoll();

        if (Input.GetKey(KeyCode.Space))
        {
            activeForwardSpeed += boostSpeed * 2 * Time.deltaTime;
        }

    }

    private void processRoll()
    {
        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRotateSpeed * Time.deltaTime, 
                          mouseDistance.x * lookRotateSpeed * Time.deltaTime, 
                          rollInput * rollSpeed * Time.deltaTime, Space.Self);

    }

    private void processMovement()
    {
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += transform.right * activeStrafeSpeed * Time.deltaTime;
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime;
    }

    private void mousePosition()
    {
        // Get coordinates on screen
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;
        // Calculate distance from the center of the screen
        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;
        // Mouse position limits
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        
    }
}
