using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 5f;
    [SerializeField]private float rotateSpeed = 10f;

    public bool isWalking;
    [SerializeField]private GameInput gameInput;
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        
        float playerRadius = .7f;
        float playerHeight = 2f;
        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove =! Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection,moveDistance);

        if (!canMove)
        {
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionX, moveDistance);
                

            if (canMove)
            {
                moveDirection = moveDirectionX;
            }
            else
            {
                Vector3 moveDirectionZ = new Vector3(0, 0, moveDirection.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionZ, moveDistance);
                   

                if (canMove)
                {
                    moveDirection = moveDirectionZ;

                }
                else
                {
                    //cannot move in any direction
                }

            }
        }

        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);
        
        isWalking = moveDirection != Vector3.zero;
        
    }
    
    

    public bool IsWalking()
    {
        return isWalking;
    }
}    
