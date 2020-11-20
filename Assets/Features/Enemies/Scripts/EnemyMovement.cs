using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed;
    private SpriteRenderer[] spriteRenderers;

    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        var targetPosition = target ? target.position : new Vector3(0, 0, 0);
        this.transform.position = Vector3.MoveTowards(
            this.transform.position,
            targetPosition,
            speed * Time.deltaTime);
        if (targetPosition.x < this.transform.position.x)
        {
            for(int i = 0; i < spriteRenderers.Length; i++){
                spriteRenderers[i].flipX = true;
            }
        }
    }
}
