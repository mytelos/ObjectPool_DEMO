using Generics.ObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DEMO : MonoBehaviour
{
    public SpawnLocation[] SpawnLocations;
    public Transform Target;
    public float minSec = 1f;
    public float maxSec = 2f;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var spawner in SpawnLocations)
        {
            StartCoroutine(Spawn_Coroutine(spawner));
        }
    }
    public IEnumerator Spawn_Coroutine(SpawnLocation spawner)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSec, maxSec));
            MonoBehaviour spawn = spawner.Spawn();
            spawn.GetComponent<NavMeshAgent>().SetDestination(Target.position);
            Clone clone = spawn.GetComponent<Clone>();
            clone.Invoke("clone.ReturnClone", Random.Range(minSec, maxSec));
        }
    }
}
