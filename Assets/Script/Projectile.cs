using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public enum Direction
    {
        Left = -1,
        right = 1
    }
    [SerializeField] private float _throwForce;

    private Rigidbody2D _rigidbody2D;

    public void rigidbody2DAddForce(Direction direction)
    {
        if (direction == Direction.Left)
        {
            _rigidbody2D.AddForce(Vector2.left * _throwForce, ForceMode2D.Impulse);
        }
        else if (direction == Direction.right)
        {
            _rigidbody2D.AddForce(Vector2.right * _throwForce, ForceMode2D.Impulse);
        }

    }
}
