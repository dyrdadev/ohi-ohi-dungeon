using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationController : MonoBehaviour
{
    private Animator _animator;
    private Vector3 lastPosition;
    public bool alwaysRunning = false;
    void Awake()
    {
        _animator = GetComponent<Animator>();
        lastPosition = this.transform.position;
    }

    void Update()
    {
        if (transform.position != lastPosition || alwaysRunning)
        {
            _animator.SetBool("isFollowing", true);
            lastPosition = transform.position;
        }
        else
        {
            _animator.SetBool("isFollowing", false);
        }
    }
}
