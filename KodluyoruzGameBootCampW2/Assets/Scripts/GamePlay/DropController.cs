using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    [SerializeField] private GameObject[] _dropGameObjects;
    private Coroutine _dropCoroutine;
    private bool isGameState;
    private void OnEnable()
    {
        isGameState = true;
        _dropCoroutine = StartCoroutine(SpawnDrop(1.5f));
    }
    private void OnDisable()
    {
        isGameState = false;
        StopCoroutine(_dropCoroutine);
    }
    private IEnumerator SpawnDrop(float spawnPerid)
    {
        WaitForSeconds wait = new WaitForSeconds(spawnPerid);
        while (true)
        {
            var gmo = Instantiate(_dropGameObjects[Random.Range(0, 2)], GetRandomSpawnPosition(), Quaternion.identity);
            yield return wait;
        }
    }
    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-Constants.X_BOUNDARY, Constants.X_BOUNDARY), Constants.DROP_HEIGHT, 0);
    }
}