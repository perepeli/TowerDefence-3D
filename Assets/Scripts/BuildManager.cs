using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one build manager exists in scene!");
            return;
        }
        instance = this;
    }



    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return (turretToBuild != null); } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Plane plane)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, plane.GetBuildPosition(), Quaternion.identity);
        plane.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, plane.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
