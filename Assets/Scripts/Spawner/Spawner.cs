using System.Collections;
using UnityEngine;

namespace Code_Advanced_Enemy_Spawn
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] private Path _path;
        [SerializeField] protected Enemy _enemyTemplate;

        private void Awake()
        {
            Validate();
            StartCoroutine(StartSpawning());
            StartCoroutine(StartRotating());
        }

        protected abstract void Validate();

        protected virtual IEnumerator StartSpawning()
        {
            float timeInterval = 1;
            WaitForSeconds waitForSeconds = new WaitForSeconds(timeInterval);

            while (true)
            {
                SpawnEnemy();

                yield return waitForSeconds;
            }
        }

        protected virtual IEnumerator StartRotating()
        {
            WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

            while (true)
            {
                _path.transform.Rotate(0, 1, 0);

                yield return waitForFixedUpdate;
            }
        }

        protected void SpawnEnemy()
        {
            if (_enemyTemplate != null)
                Instantiate<Enemy>(_enemyTemplate).Init(_path as IReadOnlyPath);
        }
    }
}