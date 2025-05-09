using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyai : MonoBehaviour
{
	
   public NavMeshAgent agent;
   public Transform player;
   public LayerMask Ground, Player;
   

   public Vector3 walkPoint;
   bool walkPointSet;
   public float walkPointRange;

   public float sightRange, attackRange;
   public bool playerInSightRange, playerInAttackRange;

   private void Awake()
   {
		  player = GameObject.Find("Player").transform;
		  agent = GetComponent<NavMeshAgent>();
   }

   private void Update()
   {
		  playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
		  playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);

		  if (!playerInSightRange && !playerInAttackRange) Patroling();
		  if (playerInSightRange && !playerInAttackRange) ChasePlayer();
		  if (playerInSightRange && playerInAttackRange) AttackPlayer();
   }

   private void Patroling()
   {
		if (!walkPointSet) SearchWalkPoint();

		if (walkPointSet)
			agent.SetDestination(walkPoint);

		Vector3 distanceToWalkPoint = transform.position - walkPoint;

		if (distanceToWalkPoint.magnitude < 1f)
			walkPointSet = false;
   }

   private void SearchWalkPoint()
   {
		  float randomZ = Random.Range(-walkPointRange, walkPointRange);
		  float randomX = Random.Range(-walkPointRange, walkPointRange);

		  walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

		  if (Physics.Raycast(walkPoint, -transform.up, 2f, Ground))
			walkPointSet = true;
   }

   private void ChasePlayer()
   {
		agent.SetDestination(player.position);
   }

   private void AttackPlayer()
   {
		agent.SetDestination(transform.position);

		transform.LookAt(player);
   }

   private void OnDrawGizmosSelected()
   {
		  Gizmos.color = Color.red;
		  Gizmos.DrawWireSphere(transform.position, attackRange);
		  Gizmos.color = Color.yellow;
		  Gizmos.DrawWireSphere(transform.position, sightRange);
   }
}
