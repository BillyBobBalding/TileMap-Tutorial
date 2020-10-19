using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    [SerializeField] private Bug bugPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bug newBug = Instantiate(bugPrefab);

            newBug.transform.position = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        }


    }
}
