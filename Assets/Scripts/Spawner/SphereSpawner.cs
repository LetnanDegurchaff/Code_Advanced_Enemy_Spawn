using Code_Advanced_Enemy_Spawn;
using System.Collections;
using UnityEngine;

public class SphereSpawner : Spawner
{
    protected override IEnumerator StartSpawning()
    {
        float timeInterval = 2;
        WaitForSeconds waitForSeconds = new WaitForSeconds(timeInterval);

        while (true)
        {
            if (GetTemplateType() == typeof(EnemySphere))
                SpawnEnemy();
            else
                StopCoroutine(SpawningCoroutine);

            yield return waitForSeconds;
        }
    }
}