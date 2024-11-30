using UnityEngine;

public class BlockMover : MonoBehaviour
{
    public Vector2 startPoint;
    public Vector2 endPoint;
    public float speed = 2f;

    private bool movingToEnd = true;

    void Update()
    {
        if (movingToEnd)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, endPoint) < 0.01f)
                movingToEnd = false;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPoint, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, startPoint) < 0.01f)
                movingToEnd = true;
        }
    }
}