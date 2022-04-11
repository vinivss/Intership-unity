using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpCharaCont : MonoBehaviour
{
    Vector3 velocity;
    [SerializeField] Rigidbody Rb;
    [Space]
    [SerializeField] float speed;
    public _3dmovement input;
    Vector2 currMov;
    Vector3 PlayerVelo;
    bool movePressed;
  


    private void Awake()
    {
        
        Rb = gameObject.GetComponent<Rigidbody>();
        input = new _3dmovement();
        input.Movement.Move.performed += ctx =>
        {
            currMov = ctx.ReadValue<Vector2>();
           
            Debug.Log("Move");
            movePressed = currMov.x != 0 || currMov.y != 0;
        };
    }

    private void Update()
    {
     
        if(!movePressed)
        {
            currMov = Vector2.zero;
        }
        PlayerVelo = new Vector3(currMov.x, 0, currMov.y);
        Rb.MovePosition(transform.position + (speed * Time.deltaTime * PlayerVelo));    
       
    }

    //HAVE THJESE TWO IN YOU DUMBASS
    private void OnEnable()
    {
        input.Movement.Enable();
    }
    private void OnDisable()
    {
        input.Movement.Disable();
    }
}
