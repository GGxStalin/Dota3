
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove: MonoBehaviour
{
    [SerializeField] float stopDistance = 0.5f;
    Player player;
    NavMeshAgent agent;
    Animator animator;
    AnimatorController animatorController;


    private void Start()
    {
        player = GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animatorController = GetComponent<AnimatorController>();
    }



    public void Move(Vector3 position)
    {
        if (agent.velocity.magnitude < 0.1f)
        {
            animatorController.SetParam("idle");
        }
        else
        {
            animatorController.SetParam("run");
        }


        if (ShouldStop(position))
        {
            CancelMove();
            return;
        }

        AllowMove();
        agent.SetDestination(position + new Vector3(0, player.transform.position.y, 0));

    }

    public void CancelMove()
    {
        agent.isStopped = true;
    }

    public void AllowMove()
    {
        agent.isStopped = false;
    }
    
    bool ShouldStop(Vector3 position)
    {
      
        return Vector3.Distance(player.transform.position, position) < stopDistance;
    }
   

    
}
