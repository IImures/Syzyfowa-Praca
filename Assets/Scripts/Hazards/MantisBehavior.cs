using System;
using System.Collections;
using System.Collections.Generic;
using Player;
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

    private void Update()
    {
        if (Math.Abs(player.GetComponent<Rigidbody2D>().velocity.x) > 2f)
        {
            Draw();
        }
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
        PlayerDeath playerDeath = player.GetComponent<PlayerDeath>();
        playerDeath.KillPlayer();
    }
}
