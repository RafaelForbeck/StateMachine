using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        enemy.GetComponent<MeshRenderer>().material = enemy.chaseMaterial;
    }

    public override void Update(Enemy enemy)
    {
        var vector = enemy.player.position - enemy.transform.position;
        var distance = vector.magnitude;

        if (distance > enemy.maxChaseDist)
        {
            enemy.ChangeState(enemy.enemyIdleState);
        } else if (distance < enemy.maxAttackDist)
        {
            enemy.ChangeState(enemy.enemyAttackState);
        } else
        {
            var movementVector = vector.normalized * enemy.speed * Time.deltaTime;
            enemy.transform.position += movementVector;
        }
    }
}
