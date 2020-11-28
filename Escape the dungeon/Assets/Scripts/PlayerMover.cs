using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    [Space]
    [SerializeField]
    private LayerMask layerToRay;
    [SerializeField]
    private float rotSpeed = 5;
    [SerializeField]
    private float speed = 5;

    private Quaternion playerRot;
    private Vector3 targetPosition;
    private Vector3 lookAt;
    private bool canMoving = false;

    private void Update()
    {
        //if (Input.GetMouseButton(0))
        //    GetPositionToMove();

        //if (canMoving) 
        //    Move();

        if (Input.GetMouseButton(0))
            SetNavMesh();
    }

    private void SetNavMesh()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            navMeshAgent.SetDestination(hit.point);
        }
    }

    private void GetPositionToMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, layerToRay.value))
        {
            targetPosition = new Vector3(hit.point.x,
                hit.point.y + 1,
                hit.point.z);
            
            lookAt = new Vector3(targetPosition.x - transform.position.x,
                targetPosition.y + 1,
                targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAt);

            canMoving = true;
        }
    }

    private void Move()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation,
        //    playerRot,
        //    rotSpeed * Time.deltaTime);

        //transform.LookAt(lookAt);
        transform.position = Vector3.MoveTowards(transform.position,
            targetPosition,
            speed * Time.deltaTime);

        if (transform.position == targetPosition) canMoving = false;
    }
}
