using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationController : MonoBehaviour
{
    private Animator _animator;
    public bool alwaysRunning;
    private Vector3 lastPosition;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    private void Update()
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