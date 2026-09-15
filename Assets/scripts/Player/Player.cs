using System;
using UnityEngine;
using UnityEngine.AI;


enum State
{
    none,
    move,
    attack
}
public class Player : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] PlayerAttack playerAttack;
    HPManager currentTarget = null;
    NavMeshAgent agent;


    [SerializeField] State currentState = State.none;
    Ray ray;
    RaycastHit hit;
    Vector3 targetPos;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                targetPos = hit.point;
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    currentState = State.attack;
                }
                else
                {
                    currentState = State.move;
                }
            }
        }
        HandleStates();
    }



    private void HandleStates()
    {
        if (currentState == State.none) return;

        else if (currentState == State.move)
        {
            currentTarget = null;
            playerAttack.StopAttack();
            playerMove.Move(targetPos);
        }
        else if (currentState == State.attack)
        {
            if (WithinAttackRadius())
            {
                playerMove.CancelMove();
                currentTarget = hit.collider.gameObject.GetComponent<HPManager>();
                playerAttack.Attack(currentTarget);
            }
            else
            {
                playerMove.Move(targetPos);
            }
        }
    }

    public bool WithinAttackRadius()
    {
        return Vector3.Distance(transform.position, targetPos) < playerAttack.attackRadius;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttack.attackRadius);
    }

}
