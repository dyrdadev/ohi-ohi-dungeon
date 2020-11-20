using UnityEngine;

public class CoinAnimationController : MonoBehaviour
{
    private Animator _animator;
    public float maxSpawnOffsetDistance = 1.0f;
    public float minSpawnOffsetDistance = 0.5f;
    public bool offsetOnSpawn = true;
    public float offsetSpeed = 1.0f;
    private Vector3 targetPosition;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlaySpawnAnimation()
    {
        // Move intro random direction
        if (offsetOnSpawn)
        {
            var offset = Random.insideUnitCircle.normalized *
                         Random.Range(minSpawnOffsetDistance, maxSpawnOffsetDistance);
            targetPosition = transform.position + new Vector3(offset.x, offset.y, 0);
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            offsetSpeed * Time.deltaTime);
    }


    public void PlayCollectedAnimation()
    {
        _animator.SetBool("collected", true);
    }
}