using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
	public Transform startPos;
	public LayerMask obstacleMask;
	public Vector2 gridWorldSize;
	public float nodeRadius;
	public float distance;

	Node[,] grid;
	public List<Node> FinalPath;
	float nodeDiameter;
	int gridSizeX, gridSizeY;

	private void Start()
	{
		nodeDiameter = nodeRadius * 2;
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
		CreateGrid();
	}

	void CreateGrid()
	{
		grid = new Node[gridSizeX, gridSizeY];
		//Vector3 bottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3
	}
}
