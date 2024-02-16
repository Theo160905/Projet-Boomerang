using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public InputMaster playerinput;

    public InputAction moveAction;

    void Start()
    {
        playerinput = GetComponent<InputMaster>();
        moveAction = playerinput.FindAction("Move");
    }

    public void MovePlayer(InputAction.CallbackContext _context)
    {
        Debug.Log("je fonctionne");
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * 1 * Time.deltaTime;
    }
}
