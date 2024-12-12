using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public enum State { Patrol, Chase, Attack, Die }

    private const float V = 2f;
    private State currentState;
    private NavMeshAgent agent;
    private List<Transform> patrolPoints = new List<Transform>(); // 순찰 경로 포인트들
    private GameObject player;
    private int currentPatrolIndex = 0;
    System.Random rand = new System.Random();
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }
    void Start()
    {
        foreach (GameObject point in GameObject.FindGameObjectsWithTag("Respawn"))
        {
            patrolPoints.Add(point.transform);
        }
        currentPatrolIndex = Random.Range(0, patrolPoints.Count);
        ChangeState(State.Patrol);
        Debug.Log(patrolPoints.Count + " " + currentPatrolIndex);
    }

    public void ChangeState(State newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Chase:
                ChasePlayer();
                break;
            case State.Attack:
                AttackPlayer();
                break;
            case State.Die:
                DIe();
                break;
        }
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    GoToNextPatrolPoint();
                }
                break;
            case State.Chase:
                agent.SetDestination(player.transform.position);
                break;
            case State.Attack:
                AttackPlayer();
                break;
            case State.Die:
                DIe();
                break;
        }
    }

    private void Patrol()
    {
        agent.speed = V; // 느린 속도로 순찰
        agent.isStopped = false;
        GoToNextPatrolPoint();
    }

    private void GoToNextPatrolPoint()
    {
        if (patrolPoints.Count == 0) return;
        agent.destination = patrolPoints[currentPatrolIndex].position;
        anim.SetBool("Walk", true);
        anim.SetBool("Run", false);
        currentPatrolIndex = currentPatrolIndex = Random.Range(0, patrolPoints.Count);

    }

    private void ChasePlayer()
    {
        //Debug.Log(agent);
        agent.isStopped = false;
        anim.SetBool("Attack", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", true);
        //agent.speed = 5f; // 빠른 속도로 추적
        //Debug.Log("Chasing the player!");
    }

    private void AttackPlayer()
    {
        anim.SetBool("Attack", true);
        agent.isStopped = true; // 공격 시 멈춤
        Invoke("AttackComplete", 0.5f);
    }

    public void AttackComplete()
    {
        //SoundManager.Instance.PlaySFX("EnemyAttack");
        if (Vector3.Distance(transform.position, player.transform.position) < 3f && currentState != State.Die)
            PlayerManager.instance.LooseHP();
    }

    private void DIe()
    {
        //Debug.Log("dead");
        agent.isStopped = true;
        anim.SetBool("Die", true);
        //Debug.Log(anim.GetParameter(2));
    }

    public void playsound(string sound)
    {
        SoundManager.Instance.PlaySFX(sound);
    }
}
