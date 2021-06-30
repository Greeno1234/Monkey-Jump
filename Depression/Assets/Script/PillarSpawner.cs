using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarSpawner : MonoBehaviour
{

    public GameObject Pillar;

    private float spawnStart = 4.7f;
    private float height = 1;
    public Transform pillarTransform;
    private bool spawned;

    private List<GameObject> activePillars;

    // Start is called before the first frame update
    private void Start()
    {      
        activePillars = new List<GameObject>();
        SpawnPillar();
        spawned = false;
    }

    // Update is called once per frame
    private void Update()
    {
        pillarTransform = activePillars[0].transform;

        if (spawned == false)
        {
            if (pillarTransform.position.x < 0.0)
            {
                SpawnPillar();
            }
        }
            
        if (pillarTransform.position.x < -4.0)
        {
            DeletePillar();
        }
    }

    private void SpawnPillar()
    {
        spawned = true;
        GameObject newmonk;
        newmonk = Instantiate(Pillar) as GameObject;
        newmonk.transform.position = transform.position + new Vector3(spawnStart, Random.Range(-height, height), 0);
        activePillars.Add(newmonk);
       
    }

    private void DeletePillar()
    {
        spawned = false;
        Destroy(activePillars[0]);
        activePillars.RemoveAt(0);
        
    }
}
