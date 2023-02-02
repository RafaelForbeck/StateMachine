using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyIdleState enemyIdleState = new EnemyIdleState();
    public EnemyChaseState enemyChaseState = new EnemyChaseState();
    public EnemyAttackState enemyAttackState = new EnemyAttackState();
    public EnemyEvadeState enemyEvadeState = new EnemyEvadeState();

    public EnemyBaseState currentState;

    public Transform player;
    public GameObject bulletModel;
    public float bulletForce;

    public float cooldown;
    public float currentCooldown = 0;

    public float speed;
    public float maxChaseDist;
    public float maxAttackDist;
    public float minAttackDist;

    public Material idleMaterial;
    public Material chaseMaterial;
    public Material attackMaterial;
    public Material evadeMaterial;

    void Start()
    {
        ChangeState(enemyIdleState);
    }

    public void ChangeState(EnemyBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.Update(this);

        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    public void Fire()
    {
        if (currentCooldown > 0)
        {
            return;
        }

        Vector3 direction = player.position - transform.position;
        Vector3 force = direction.normalized * bulletForce;

        GameObject bulletGO = Instantiate(bulletModel, transform.position, transform.rotation);
        Destroy(bulletGO, 2);
        Rigidbody rig = bulletGO.GetComponent<Rigidbody>();

        rig.AddForce(force);
        currentCooldown = cooldown;
    }
}
