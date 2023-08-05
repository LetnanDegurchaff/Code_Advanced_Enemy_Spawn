using Code_Advanced_Enemy_Spawn;

public class CubeSpawner : Spawner
{
    protected override void Validate()
    {
        if ((_enemyTemplate is EnemyCube) == false)
        {
            _enemyTemplate = null;
        }
    }
}