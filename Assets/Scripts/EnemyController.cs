using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Path path;
    private int currentPoint = 0;
    private bool reachedEnd = false;

    public float timeBetweenAttacks, damagePerAttack;
    private float attackCounter;

    private Castle castle;

    private int selectedAttackPoint;

    void Start()
    {
        if(path == null)
            path = GameObject.FindObjectOfType<Path>();

        if(castle == null)
            castle = GameObject.FindObjectOfType<Castle>();

        attackCounter = timeBetweenAttacks;
    }

    void Update()
    {
        if(LevelManager.instance.levelActive)
        {
            if(!reachedEnd)
            {
            FollowPath();
            }
            else
            {
                Attack();
            } 
        }
    }

    private void Attack()
    {
        if(castle != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, castle.attackPoints[selectedAttackPoint].position, moveSpeed * Time.deltaTime);

            attackCounter -= Time.deltaTime;

            if(attackCounter <= 0)
            {
                attackCounter = timeBetweenAttacks;
                castle.TakeDamage(damagePerAttack);
            }
        }
    }

    private void FollowPath()
    {
        transform.position = Vector3.MoveTowards(transform.position, path.points[currentPoint].position, moveSpeed * Time.deltaTime);
        transform.LookAt(path.points[currentPoint].position);
            if (Vector3.Distance(transform.position, path.points[currentPoint].position) < 0.1f)
            {
                currentPoint++;
                if (currentPoint >= path.points.Length)
                {
                    reachedEnd = true;

                    selectedAttackPoint = Random.Range(0, castle.attackPoints.Length);
                }
            }
    }

    public void Setup(Castle newCastle, Path newPath)
    {
        castle = newCastle;
        path = newPath;
    }
}
