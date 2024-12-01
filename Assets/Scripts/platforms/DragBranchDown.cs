using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBranchDown : ActionOnDrag
{
    [SerializeField] private float timer = 2f;
    [SerializeField] private GameObject originalPos;
    [SerializeField] private GameObject leanedPos;
    private Animator _grassAnimator;

    private void Start()
    {
        originalPos.transform.parent = null;
        leanedPos.transform.parent = null;
        _grassAnimator = GetComponentInParent<Animator>();
    }

    protected override void PerformAction(Vector2 drag)
    {
        StartCoroutine(LeanBranch());
    }

    private IEnumerator LeanBranch()
    {
        _grassAnimator.SetTrigger("Lean");
        while (!ComparePos(leanedPos.transform.position))
        {
            MoveObject(leanedPos.transform.position,3f);
            yield return null;
        }
        yield return new WaitForSeconds(timer);
        _grassAnimator.SetTrigger("Go Back");
        while (!ComparePos(originalPos.transform.position))
        {
            MoveObject(originalPos.transform.position,3f);
            yield return null;
        }
    }

    private bool ComparePos(Vector2 pos)
    {
        bool horizontal = Math.Abs(pos.x - gameObject.transform.position.x)<0.01;
        bool vertical = Math.Abs(pos.y - gameObject.transform.position.y)<0.01;
        return horizontal && vertical;
    }

    private void MoveObject(Vector2 pos, float step)
    {
        gameObject.transform.position = Vector2.MoveTowards(
            gameObject.transform.position,
            pos,
            step * Time.deltaTime
        );
    }
}
