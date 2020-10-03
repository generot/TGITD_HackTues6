using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRankGuard : MonoBehaviour
{
    BaseEnemy b_enemy;
    public Transform platform;

    EndPoints bndry;

    void Start()
    {
        b_enemy = new BaseEnemy();
        bndry = new EndPoints(
            new Vector2(platform.position.x - platform.lossyScale.x * 4, platform.position.y),
            new Vector2(platform.position.x + platform.lossyScale.x * 4, platform.position.y)
        );

        //print(platform.localPosition.x + " " + platform.localPosition.y);
    }

    void Update()
    {
        transform.localPosition = b_enemy.Pathfinding(transform.localPosition, bndry);
    }
}
