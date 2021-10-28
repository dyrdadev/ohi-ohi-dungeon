using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
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

    public void PushBack(float duration, float strength, AnimationCurve speedChangeCurve)
    {
        StartCoroutine(PushBackRoutine(duration, strength, speedChangeCurve));
    }

    private IEnumerator PushBackRoutine(float duration, float strength, AnimationCurve speedChangeCurve )
    {
        float timer = 0;

        float originalSpeed = speed;

        while (timer < duration)
        {
            speed = originalSpeed - (speedChangeCurve.Evaluate(timer / duration) * originalSpeed * strength * 2);

            yield return new WaitForSecondsRealtime(Time.deltaTime);
            timer += Time.deltaTime;
        }
        
        speed = originalSpeed;
    }
}