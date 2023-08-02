using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code_Advanced_Enemy_Spawn
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyTemplate;
        [SerializeField] private List<Transform> _serializePath;

        private List<IReadOnlyTransform> _path;

        protected Coroutine SpawningCoroutine;

        private void Awake()
        {
            _path = new List<IReadOnlyTransform>();

            foreach (Transform transform in _serializePath)
                _path.Add(new IReadOnlyTransform(transform));

            SpawningCoroutine = StartCoroutine(StartSpawning());
        }

        protected Type GetTemplateType() => _enemyTemplate.GetType();

        protected virtual IEnumerator StartSpawning()
        {
            float timeInterval = 2;
            WaitForSeconds waitForSeconds = new WaitForSeconds(timeInterval);

            while (true)
            {
                SpawnEnemy();

                yield return waitForSeconds;
            }
        }

        protected void SpawnEnemy() => 
            Instantiate<Enemy>(_enemyTemplate).Init(GetPath());

        private IReadOnlyList<IReadOnlyTransform> GetPath() => _path;
    }
}