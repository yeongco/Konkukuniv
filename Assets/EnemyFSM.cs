using JetBrains.Annotations;
using System;
using System.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public enum State { Patrol, Chase, Attack, Die }

    private const float V = 2f;
    private State currentState;
    private NavMeshAgent agent;
    public Transform[] patrolPoints; // 순찰 경로 포인트들
    private int currentPatrolIndex;
    System.Random rand = new System.Random();
    private Animator anim;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        currentPatrolIndex = rand.Next(0,patrolPoints.Length);
        ChangeState(State.Patrol);
        anim = GetComponent<Animator>();
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
                agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
                break;
            case State.Attack:
                // 플레이어를 공격하는 로직 작성
                
                break;
        }
    }

    private void Patrol()
    {
        agent.speed = V; // 느린 속도로 순찰
        GoToNextPatrolPoint();
    }

    private void GoToNextPatrolPoint()
    {
        agent.isStopped = false;
        if (patrolPoints.Length == 0) return;
        agent.destination = patrolPoints[currentPatrolIndex].position;
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    private void ChasePlayer()
    {
        agent.isStopped = false;
        agent.speed = 5f; // 빠른 속도로 추적
        Debug.Log("Chasing the player!");
    }

    private void AttackPlayer()
    {
        agent.isStopped = true; // 공격 시 멈춤
        PlayerManager.instance.LooseHP();
    }

    private void DIe()
    {
        agent.isStopped = true;
    }
}
