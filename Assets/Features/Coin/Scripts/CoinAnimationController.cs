using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimationController : MonoBehaviour
{
    public bool offsetOnSpawn = true;
    public float offsetSpeed = 1.0f;
    public float minSpawnOffsetDistance = 0.5f;
    public float maxSpawnOffsetDistance = 1.0f;
    private Vector3 targetPosition;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlaySpawnAnimation()
    {
        // Move intro random direction
        if (offsetOnSpawn)
        {
            var offset = Random.insideUnitCircle.normalized * Random.Range(minSpawnOffsetDistance, maxSpawnOffsetDistance);
            targetPosition = transform.position + new Vector3(offset.x, offset.y, 0);
        }
    }

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(
            this.transform.position,
            targetPosition,
            offsetSpeed * Time.deltaTime);
    }


    
    public void PlayCollectedAnimation()
    {
        _animator.SetBool("collected", true);
    }
}
