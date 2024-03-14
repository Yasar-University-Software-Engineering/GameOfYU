using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    CarNavigationController controller;
    public Waypoint currentWaypoint;

    private void Awake()
    {
        controller = GetComponent<CarNavigationController>();
    }

    void Start()
    {
        // Aracýn ilk hedefini currentWaypoint olarak ayarla
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    void Update()
    {
        if (controller.reachedDestination)
        {
            bool shouldBranch = false;

            // Eðer mevcut waypoint'te dallanma varsa, rastgele bir dal seç
            if (currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRatio;
            }

            if (shouldBranch)
            {
                currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count)];
            }
            else
            {
                currentWaypoint = currentWaypoint.nextWaypoint;
            }

            controller.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
