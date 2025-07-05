using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMoveToTransform : MonoBehaviour
{
    public enum AIState { Idle, Detect, Chase, Attack }
    private AIState currentState = AIState.Idle;

    [Header("AI Movement")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 1.5f;

    [Header("AI Health")]
    [SerializeField] private int maxHp = 100;
    [SerializeField]private int currentHp;

    private Transform player;
    private int currentPatrolIndex = 0;
    private float lastAttackTime = -999f;

    public AudioClip DeathAudioClip;
    [Range(0, 1)] public float DeathAudioVolume = 0.5f;

    void Start()
    {
        currentHp = maxHp;
        player = PlayerLocatorSingleton.Instance.transform;
        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    void Update()
    {
        if (player == null || currentHp <= 0) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case AIState.Idle:
                Patrol();
                if (distanceToPlayer < detectionRange)
                {
                    currentState = AIState.Detect;
                }
                break;

            case AIState.Detect:
                currentState = AIState.Chase;
                break;

            case AIState.Chase:
                agent.SetDestination(player.position);
                if (distanceToPlayer <= attackRange)
                {
                    currentState = AIState.Attack;
                }
                else if (distanceToPlayer > detectionRange * 1.5f)
                {
                    currentState = AIState.Idle;
                    agent.SetDestination(patrolPoints[currentPatrolIndex].position);
                }
                break;

            case AIState.Attack:
                agent.ResetPath();
                transform.LookAt(player);

                if (Time.time - lastAttackTime > attackCooldown)
                {
                    Debug.Log("AI Attack!");
                    lastAttackTime = Time.time;
                }

                if (distanceToPlayer > attackRange)
                {
                    currentState = AIState.Chase;
                }
                break;
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }


    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage! Remaining HP: {currentHp}");

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        agent.isStopped = true;
        AudioSource.PlayClipAtPoint(DeathAudioClip, transform.position, DeathAudioVolume);
        Destroy(gameObject);
    }
}
