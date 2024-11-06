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
        transform.position += moveDirection * moveSpeed* Time.deltaTime;
        
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);
        
        isWalking = moveDirection != Vector3.zero;
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}    
