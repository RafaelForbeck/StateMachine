using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        enemy.GetComponent<MeshRenderer>().material = enemy.idleMaterial;
    }

    public override void Update(Enemy enemy)
    {
        var vector = enemy.player.position - enemy.transform.position;
        var distance = vector.magnitude;

        if (distance < enemy.maxChaseDist)
        {
            enemy.ChangeState(enemy.enemyChaseState);
        }
    }
}
