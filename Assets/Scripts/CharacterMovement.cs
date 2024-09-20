using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class CharacterMovement : MonoBehaviour
{
    private float speed = 1.0f;
    private Vector2 direction = Vector2.zero;

    public void MoveCharacter(InputAction.CallbackContext context)
    {
        Debug.Log("Input Pressed");
        direction = context.ReadValue<Vector2>(); 
    }

    private void Update()
    {
        transform.position += (Vector3)direction * Time.deltaTime * speed;
    }

    private void MoveRight()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }
}
