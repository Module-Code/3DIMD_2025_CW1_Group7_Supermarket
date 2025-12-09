using UnityEngine;

public class ClickToMoveAndWave : MonoBehaviour
{
    public Transform checkoutSpot;     
    public Animator animator;          
    public string waveTrigger = "PlayScan"; 

    public float movespeed = 5f;       
    public float stopdistance = 1.2f;  
    public float turnspeed = 5f;       

    public bool isMoving = false;
    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    { if (Input.GetMouseButtonDown(0))
      {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider.gameObject == gameObject)
                {
                    
                    OnMouseDown();
                }
            }
      }
        if (isMoving)
        {
            
            Vector3 direction = checkoutSpot.position - transform.position;
            direction.y = 0f;

            
            if (direction.magnitude > stopdistance)
            {
                
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnspeed * Time.deltaTime);

               
                cc.Move(direction.normalized * movespeed * Time.deltaTime);
            }
            else
            {
                
                isMoving = false;
                animator.SetTrigger(waveTrigger);
            }
        }
    }

    void OnMouseDown()
    {
        isMoving = true; 
    }
}
