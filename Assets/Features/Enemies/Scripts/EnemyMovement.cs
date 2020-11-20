using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private SpriteRenderer[] spriteRenderers;
    public Transform target;

    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        var targetPosition = target ? target.position : new Vector3(0, 0, 0);
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime);
        if (targetPosition.x < transform.position.x)
        {
            for (var i = 0; i < spriteRenderers.Length; i++)
            {
                spriteRenderers[i].flipX = true;
            }
        }
    }
}