using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemiesPrefab;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private AudioClip clipSpawn;

    public float lastEnemyActive;

    private void Update()
    {
        if (GameStateManager.Instance.CurrentGameState == GameState.PLAYING && (lastEnemyActive < Time.time))
            InvokeEnemy(enemiesPrefab);
    }

    private void InvokeEnemy(GameObject[] enemiesPrefab)
    {

        bool setActive = false;
        Dictionary<int, bool> randIndexesUsed = new();
        float countSpawnersActivated = 0;

        while (!setActive || randIndexesUsed.Count == enemiesPrefab.Length)
        {
            if(randIndexesUsed.Count == enemiesPrefab.Length)
                break;

            var randomIndex = Random.Range(0, enemiesPrefab.Count());

            if (randIndexesUsed.ContainsKey(randomIndex) && randIndexesUsed[randomIndex])
                continue;

            randIndexesUsed[randomIndex] = true;
            var enemySelected = enemiesPrefab[randomIndex];

            if (enemySelected.activeSelf)
                continue;

            enemySelected.transform.position = transform.position;
            enemySelected.SetActive(true);
            countSpawnersActivated++;
            setActive = true;
            AudioController.Instance.PlaySoundEffect(clipSpawn);
        }

        lastEnemyActive = Time.time + spawnInterval;
    }
}
