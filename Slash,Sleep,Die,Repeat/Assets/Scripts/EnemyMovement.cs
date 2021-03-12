using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    public float speed;
    Vector2 spawn;
    [SerializeField] LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
        rb = GetComponent<Rigidbody2D>();
        spawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

	private void FixedUpdate()
	{
        Move();
    }

	void Move()
    {
        if (ZoneCon.instance.activeZone != null && ZoneCon.instance.activeZone.GetComponent<BoxCollider2D>().IsTouching(GetComponent<CircleCollider2D>()))
        {
            ChasePlayer();
        }
        else
        {
            GoToSpawn();
        }


		
		//if intersect with not a player
		//raycast to shorter side
		//raycast again and move 
		//else
		//move to player
	}

    void ChasePlayer()
    {
        //Vector2 direction = player.transform.position - transform.position;
        //direction.Normalize();
        //rb.AddForce(direction * speed);
        //transform.up = (Vector2)player.transform.position - (Vector2)transform.position;


        //raycast to player
        Vector2 direction = player.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction, 10000, mask);
        if (hit)
        {
            if (hit.collider.GetComponent<Player>())
            {
                direction.Normalize();
                rb.AddForce(direction * speed);
                transform.up = (Vector2)player.transform.position - (Vector2)transform.position;
            }
            else
            {
                Vector2 tempDirection = direction;
                tempDirection.x = direction.y;
                tempDirection.y = -direction.x;
          
                tempDirection.Normalize();
                rb.AddForce(tempDirection * speed);
                transform.up = (Vector2)player.transform.position - (Vector2)transform.position;
                //NewDirection(10, hit.collider);
            }
        }
    }
    //navigates around objects downwards
 //   void NewDirection(int amount, Collider2D collider)
	//{
 //       Vector2 directionDown = player.transform.position - transform.position;
 //       directionDown.y -= amount;
 //       RaycastHit2D hit2 = Physics2D.Raycast((Vector2)transform.position, directionDown);
 //       if (hit2.collider != collider)
 //       {
 //           directionDown.Normalize();
 //           rb.AddForce(directionDown * speed);
 //           transform.up = (Vector2)player.transform.position - (Vector2)transform.position;
 //       }
 //       else
	//	{
 //           NewDirection(10,collider);
	//	}
 //   }
    void GoToSpawn()
    {
        if (Mathf.Abs(transform.position.x - spawn.x) > 0.1f ||
            Mathf.Abs(transform.position.y - spawn.y) > 0.1f)
        {
            Vector2 direction = spawn - (Vector2)transform.position;
            direction.Normalize();
            rb.AddForce(direction * speed);
            transform.up = spawn - (Vector2)transform.position;
        }
    }
}
