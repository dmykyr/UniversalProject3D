using System.Collections.Generic;
using UnityEngine;

public class DroneManager : MonoBehaviour
{
    public static DroneManager instance;

    public GameObject drone;
    public GameObject[] dronePrefabs;
    public Dictionary<string, int> dronePrefabsKeys = new()
    {
        { "Drone Red", 0 },
        { "Drone Orange", 1 },
        { "Drone Blue", 2 },
        { "Drone Black", 3 }
    }; 


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeDrones();
        }
    }

    public void InitializeDrones()
    {
        foreach (GameObject dronePrefab in dronePrefabs)
        {
            DontDestroyOnLoad(dronePrefab);
            dronePrefab.SetActive(false);
        }

        DontDestroyOnLoad(drone);
        drone.SetActive(false);
    }

    public void ChangeCurrentDroneSkin(int index)
    {
        if (index < 0 || index >= dronePrefabs.Length)
        {
            return;
        }

        ChangeDronePrefab(drone, dronePrefabs[index]);
    }

    public void ChangeDronePrefab(GameObject currentDrone, GameObject newDrone)
    {
        MeshFilter droneMeshFilter = currentDrone.GetComponent<MeshFilter>();
        MeshRenderer droneMeshRenderer = currentDrone.GetComponent<MeshRenderer>();

        MeshFilter newMeshFilter = newDrone.GetComponent<MeshFilter>();
        MeshRenderer newMeshRenderer = newDrone.GetComponent<MeshRenderer>();

        if (droneMeshFilter != null && newMeshFilter != null)
        {
            droneMeshFilter.mesh = newMeshFilter.mesh;
        }

        if (droneMeshRenderer != null && newMeshRenderer != null)
        {
            droneMeshRenderer.materials = newMeshRenderer.materials;
        }

        Transform[] droneChildren = currentDrone.GetComponentsInChildren<Transform>();
        Transform[] newDroneChildren = newDrone.GetComponentsInChildren<Transform>();

        for (int i = 0; i < droneChildren.Length; i++)
        {
            MeshFilter childMeshFilter = droneChildren[i].GetComponent<MeshFilter>();
            MeshRenderer childMeshRenderer = droneChildren[i].GetComponent<MeshRenderer>();

            MeshFilter newChildMeshFilter = newDroneChildren[i].GetComponent<MeshFilter>();
            MeshRenderer newChildMeshRenderer = newDroneChildren[i].GetComponent<MeshRenderer>();

            if (childMeshFilter != null && newChildMeshFilter != null)
            {
                childMeshFilter.mesh = newChildMeshFilter.mesh;
            }

            if (childMeshRenderer != null && newChildMeshRenderer != null)
            {
                childMeshRenderer.materials = newChildMeshRenderer.materials;
            }
        }
    }

    public GameObject GetCurrentDrone()
    {
        return drone;
    }
}
