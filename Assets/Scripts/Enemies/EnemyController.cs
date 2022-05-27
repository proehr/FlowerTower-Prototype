using System;
using System.Collections;
using MapGeneration;
using UnityEngine;

namespace Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;

        private void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            Instantiate(enemyPrefab, transform);

            yield return new WaitForSeconds(2);
            StartCoroutine(SpawnEnemy());
        }
    }
}