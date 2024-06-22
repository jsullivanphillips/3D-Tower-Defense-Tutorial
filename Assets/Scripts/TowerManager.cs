using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public Tower activeTower;

    public Transform indicator;
    public bool isPlacing;

    public LayerMask whatIsPlacement, whatIsObstacle;

    public float topSafePercent = 12f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(isPlacing)
        {
            indicator.gameObject.SetActive(true);

            indicator.position = GetGridPosition();

            RaycastHit hit;

            if(Input.mousePosition.y > Screen.height * (1 - topSafePercent / 100f))
            {
                indicator.gameObject.SetActive(false);
            }
            else if(Physics.Raycast(indicator.position + new Vector3(0f,-2f,0f), Vector3.up, out hit, 10f, whatIsObstacle))
            {
                indicator.gameObject.SetActive(false);
            }
            else
            {
                indicator.gameObject.SetActive(true);

                UIController.instance.notEnoughMoneyLabel.SetActive(MoneyManager.instance.currentMoney < activeTower.cost);

                if(Input.GetMouseButtonDown(0))
                {
                    if(MoneyManager.instance.SpendMoney(activeTower.cost))
                    {
                        isPlacing = false;

                        Instantiate(activeTower, indicator.position, activeTower.transform.rotation);

                        indicator.gameObject.SetActive(false);
                    }
                }
            }

            if(Input.GetMouseButtonDown(1))
            {
                isPlacing = false;
                indicator.gameObject.SetActive(false);
                UIController.instance.notEnoughMoneyLabel.SetActive(false);
            }
        }
        
    }

    public void StartTowerPlacement(Tower towerToPlace)
    {
        activeTower = towerToPlace;
        isPlacing = true;
        Destroy(indicator.gameObject);

        Tower placeTower = Instantiate(activeTower, indicator.position, activeTower.transform.rotation);
        placeTower.enabled = false;
        placeTower.GetComponent<Collider>().enabled = false;
        indicator = placeTower.transform;
        placeTower.rangeModel.SetActive(true);
        placeTower.rangeModel.transform.localScale = new Vector3(placeTower.range, 1, placeTower.range);
    }

    private Vector3 GetGridPosition()
    {
        Vector3 location  = Vector3.zero;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 200f, whatIsPlacement))
        {
            location = hit.point;
        }

        location.y = 0;

        return location;
    }
}
