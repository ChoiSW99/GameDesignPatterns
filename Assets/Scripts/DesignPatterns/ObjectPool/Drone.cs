using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Drone : MonoBehaviour
{
    public IObjectPool<Drone> Pool { get; set; }

    [SerializeField]
    private float _currentHealth;
    private float _maxHealth = 100f;

    [SerializeField]
    private float _timeToSelfDestruct = 3f;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    void OnEnable()
    {
        AttackPlayer();
        StartCoroutine(SelfDestruct());
    }

    public void AttackPlayer()
    {
        Debug.Log("Attack Player!");
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(_timeToSelfDestruct);
        TakeDamage(_maxHealth);
    }
    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0f)
            ReturnToPool();
    }
    private void ReturnToPool()
    {
        Pool.Release(this);
    }

    void OnDisable()
    {
        ResetDrone();
    }

    private void ResetDrone()
    {
        _currentHealth = _maxHealth;
    }
        
}
