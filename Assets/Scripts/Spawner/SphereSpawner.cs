using Code_Advanced_Enemy_Spawn;

public class SphereSpawner : Spawner
{
    protected override void Validate()
    {
        if ((_enemyTemplate is EnemySphere) == false)
        {
            _enemyTemplate = null;
        }
    }
}