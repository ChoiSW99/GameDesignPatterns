using UnityEngine;
using UnityEngine.Pool;

public class DroneObjectPool : MonoBehaviour
{
    public int maxPoolSize = 20;
    public int stackDefaultCapacity = 10;

    private IObjectPool<Drone> _pool;
    public IObjectPool<Drone> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<Drone>(CreatedPooledItem, OnTakeFromPool,
                        OnReturnedToPool, OnDestroyPoolObject,
                        true, stackDefaultCapacity, maxPoolSize );
            }
            return _pool;
        }
    }

    #region Pool Callbaks
    private Drone CreatedPooledItem()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Drone drone = go.AddComponent<Drone>();
        go.name = "Drone";
        drone.Pool = Pool;

        return drone;
    }

    private void OnTakeFromPool(Drone drone)
    {
        drone.gameObject.SetActive(true);
    }
    private void OnReturnedToPool(Drone drone)
    {
        drone.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(Drone drone)
    {
        Destroy(drone.gameObject);
    }
    #endregion

    public void Spawn()
    {
        int ammount = UnityEngine.Random.Range(1, 10);
        for (int i = 0; i < ammount; i++)
        {
            Drone drone = Pool.Get();
            drone.transform.position = UnityEngine.Random.insideUnitCircle * 10;
        }
    }

}
