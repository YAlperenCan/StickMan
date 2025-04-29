using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var collision=GetComponentsInChildren<Collider2D>();

        for (int i = 0; 1 < collision.Length; i++)
        {
            for (int j = i + 1; j < collision.Length; j++)

            {
                Physics2D.IgnoreCollision(collision[i], collision[j]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
