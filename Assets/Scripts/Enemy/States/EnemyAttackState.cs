using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        enemy.GetComponent<MeshRenderer>().material = enemy.attackMaterial;
    }

    public override void Update(Enemy enemy)
    {
        enemy.Fire();

        var vector = enemy.player.position - enemy.transform.position;
        var distance = vector.magnitude;

        if (distance > enemy.maxAttackDist)
        {
            enemy.ChangeState(enemy.enemyChaseState);
        } else if (distance < enemy.minAttackDist)
        {
            enemy.ChangeState(enemy.enemyEvadeState);
        }
    }
}
