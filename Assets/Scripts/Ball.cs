using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    private ContactFilter2D contactFilter;

    [SerializeField] private UnityEvent onEvent;
    [SerializeField] private UnityEvent<float> offEvent;
    [SerializeField] private UnityEvent<float> offEvent2;
    [SerializeField] private UnityEvent<Voiture> cameraEvent; 

    private void DetectionExemple()
    {

        contactFilter = new ContactFilter2D()
        {
            useTriggers = true,
            useDepth = true,
            minDepth = -10,
            maxDepth = 10,
        };


        RaycastHit2D[] hitArray = new RaycastHit2D[4];
        int _hitCount = Physics2D.CircleCast(transform.position,
                            2.0f,
                            transform.right,
                            contactFilter,
                            hitArray,
                            15f);
        if (_hitCount > 0)
        {
            Debug.DrawRay(transform.position, (Vector3)hitArray[0].point - transform.position, Color.red, 6f);
            for (int i = 0; i < _hitCount; i++)
            {
                if (hitArray[i].collider.TryGetComponent(out HitDebug hitDebug))
                {
                    hitDebug.DebugOnHit();
                }
            }
        }

    }

    private Coroutine movementCoroutine; 
    private void Start()
    {
        movementCoroutine = StartCoroutine(GoToPosition(Vector2.right * 10));
        offEvent?.Invoke(10f); 
    }

    private void Update()
    {
        if(Time.time > 2.0f && movementCoroutine is not null)
        {
            StopCoroutine(movementCoroutine); 
            movementCoroutine = null;
        }

    }

    private IEnumerator GoToPosition(Vector2 _targetPosition)
    {
        transform.localScale = Vector3.one * 5;
        yield return new WaitForSeconds(1.0f); 
        transform.localScale = Vector3.one;

        while (Vector2.Distance(transform.position, _targetPosition) > Mathf.Epsilon)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, .1f);
            yield return new WaitForSeconds(.5f); 
        }
    }

    public void OffMethod(float _value)
    {

    }
}
