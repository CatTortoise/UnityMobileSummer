using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum PlayerNumber { PlayerOne, PlayerTwo}
public class PlayerController : MonoBehaviour
{
   //[SerializeField] private PlayerNumber playerNumber;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private LocationMarkerScript locationMarker;
    [SerializeField] private float moveSpeed;
    //[SerializeField] private float flyingHeight;
    //[SerializeField] private float minFlyingVelocity;

    //public PlayerNumber PlayerNumber { get => playerNumber;private set => playerNumber = value; }

    // Update is called once per frame
    private void FixedUpdate()
    {
       /*float height;
        if (Mathf.Abs(playerRigidbody.velocity.x) < minFlyingVelocity)
            height = locationMarker.transform.position.y;
        else
            height = flyingHeight;*/
        Vector2 moveTo = Vector2.Lerp(transform.position,new(locationMarker.transform.position.x,transform.position.y), moveSpeed * Time.deltaTime);
        playerRigidbody.AddForce((moveTo - new Vector2(transform.position.x, transform.position.y)) * moveSpeed * Time.deltaTime,ForceMode2D.Impulse);
    }
    

}
