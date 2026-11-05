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
    [SerializeField] GameObject rightClickEffect;
    HPManager currentTarget = null;
    NavMeshAgent agent;
    AnimatorController animatorController;


    [SerializeField] State currentState = State.move;
    Ray ray;
    RaycastHit hit;
    Vector3 targetPos;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        animatorController = GetComponent<AnimatorController>();
        playerMove = GetComponent<PlayerMove>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(1))
        //{

        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        //    {
        //        Instantiate(rightClickEffect, hit.point, Quaternion.Euler(90, 0, 0));

        //        targetPos = hit.point;
        //        if (hit.collider.gameObject.CompareTag("Enemy"))
        //        {
        //            currentState = State.attack;
        //        }
        //        else
        //        {
        //            currentState = State.move;
        //        }
        //    }
        //}
        //HandleStates();


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animatorController.SetParam("skill1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animatorController.SetParam("skill2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animatorController.SetParam("skill3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animatorController.SetParam("skill4");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            animatorController.SetParam("skill5");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            animatorController.SetParam("skill6");
        }
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
