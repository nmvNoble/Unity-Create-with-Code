using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U5GameManager : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 1.0f;
    public List<GameObject> targets;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
