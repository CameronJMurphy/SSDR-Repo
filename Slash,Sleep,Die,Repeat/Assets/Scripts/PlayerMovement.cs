using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    SpriteRenderer playerRenderer;
    [SerializeField] List<Sprite> playerSprites;
    Rigidbody2D rb;
 
    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

	private void FixedUpdate()
	{
        float speed = Player.instance.GetStats().GetMovespeed();
        if (Input.GetKey(KeyCode.W))
        {
            playerRenderer.sprite = playerSprites[0];
            rb.AddForce(new Vector2(0, 1 * speed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRenderer.sprite = playerSprites[1];
            rb.AddForce(new Vector2(-1 * speed, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRenderer.sprite = playerSprites[2];
            rb.AddForce(new Vector2(0, -1 * speed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRenderer.sprite = playerSprites[3];
            rb.AddForce(new Vector2(1 * speed, 0));
        }
    }
}
