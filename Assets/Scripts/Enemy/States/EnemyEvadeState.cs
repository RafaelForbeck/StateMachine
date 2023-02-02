using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvadeState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        enemy.GetComponent<MeshRenderer>().material = enemy.evadeMaterial;
    }

    public override void Update(Enemy enemy)
    {
        var vector = enemy.transform.position - enemy.player.position;
        var distance = vector.magnitude;
        var movementVector = vector.normalized * enemy.speed * Time.deltaTime;
        enemy.transform.position += movementVector;

        if (distance > enemy.minAttackDist)
        {
            enemy.ChangeState(enemy.enemyAttackState);
        }
    }
}
