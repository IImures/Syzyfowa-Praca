using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBranchDown : ActionOnDrag
{
    [SerializeField] private float timer = 2f;
    [SerializeField] private Vector2 leanedPos = new Vector2();
    private Vector2 _originalPos;

    private void Start()
    {
        _originalPos = transform.position;
    }
    protected override void PerformAction(Vector2 drag)
    {
        StartCoroutine(LeanBranch());
    }

    private IEnumerator LeanBranch()
    {
        gameObject.transform.position = leanedPos;
        yield return new WaitForSeconds(timer);
        gameObject.transform.position = _originalPos;
    }
}
