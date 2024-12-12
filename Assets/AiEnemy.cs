using UnityEngine;
using UnityEngine.AI;

public class AiEnemy : MonoBehaviour
{
    private Transform player; // �÷��̾��� Transform�� �Ҵ�
    private NavMeshAgent agent;
    private EnemyFSM enemyFSM;

    // �Ÿ� ����
    private float attackDistance = 3f;
    private float chaseDistance = 20f;
    public bool Is_Dead = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        /*agent = GetComponent<NavMeshAgent>();*/
        enemyFSM = GetComponent<EnemyFSM>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);


        // ���� ����
        if (Is_Dead)
            enemyFSM.ChangeState(EnemyFSM.State.Die);
        else if (distanceToPlayer <= attackDistance)
        {
            enemyFSM.ChangeState(EnemyFSM.State.Attack);
            //Debug.Log("Attack");
        }
        else if (distanceToPlayer <= chaseDistance)
        {
            enemyFSM.ChangeState(EnemyFSM.State.Chase);
            //Debug.Log("Chase");
        }
        else
        {
            enemyFSM.ChangeState(EnemyFSM.State.Patrol);
            //Debug.Log("Patrol");
        }
    }
}
