using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3f;
    public LayerMask whatIsEnemy;

    private Collider[] collidersInRange;
    public List<EnemyController> enemiesInRange = new List<EnemyController>();

    private float checkCounter;
    public float checkTime = 0.2f;

    [HideInInspector]
    public bool enemiesUpdated;

    public GameObject rangeModel;

    public int cost = 100;

    // Start is called before the first frame update
    void Start()
    {
        checkCounter = checkTime;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesUpdated = false;
        
        checkCounter -= Time.deltaTime;
        if(checkCounter <= 0)
        {
            checkCounter = checkTime;
            CheckForEnemiesInRange();
        }
    }

    private void CheckForEnemiesInRange()
    {
        collidersInRange = Physics.OverlapSphere(transform.position, range, whatIsEnemy);

        enemiesInRange.Clear();
        foreach(var collider in collidersInRange)
        {
            var enemy = collider.GetComponent<EnemyController>();
            if(enemy != null)
            {
                enemiesInRange.Add(enemy);
            }
        }
        enemiesUpdated = true;
    }
}
