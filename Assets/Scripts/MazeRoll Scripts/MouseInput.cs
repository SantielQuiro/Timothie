using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInput : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float rotationSpeed;
    [SerializeField] float maxRotationAngle;
    [SerializeField] float minRotationAngle;

    public Vector3 mousePosition;
    public InputActionReference deltaMouse;
    bool OnMinigame;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        OnMinigame = true; 
    }

    private void Update()
    {
        Debug.Log("Mouse Position: " + mousePosition + " and " + OnMinigame); 
        mousePosition = deltaMouse.action.ReadValue<Vector2>();

        if (OnMinigame)
        {
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the game window
            //Cursor.visible = false; // Hide the cursor
        }
    }
    private void FixedUpdate()
    {
        rb.AddTorque(new Vector3(mousePosition.y, 0, -mousePosition.x) * rotationSpeed * Time.fixedDeltaTime);
        /*rb.rotation = Quaternion.Euler(
            Mathf.Clamp(rb.rotation.eulerAngles.x, minRotationAngle, maxRotationAngle),
            rb.rotation.eulerAngles.y,
            Mathf.Clamp(rb.rotation.eulerAngles.z, minRotationAngle, maxRotationAngle)
        );*/
    }
}
