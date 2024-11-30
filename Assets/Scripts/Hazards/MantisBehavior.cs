using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantisBehavior : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mouth;
    private LineRenderer _lineRenderer;
    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
    }

    private void Start()
    {
        StartCoroutine(Spit());
    }

    public IEnumerator Spit()
    {
        yield return new WaitForSeconds(2f);
        Draw();
    }

    public void Draw()
    {
        _lineRenderer.SetPosition(0,mouth.transform.position);
        _lineRenderer.SetPosition(1,player.transform.position);
    }
}
