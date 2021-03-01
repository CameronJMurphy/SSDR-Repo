using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
	public int x;
	public int y;

	public bool isObstacle;
	public Vector3 pos;
	public Node parent;

	public int gCost;
	public int hCost;
	public int FCost { get { return gCost + hCost; } }

	public Node(bool obstacle, Vector3 p, int _x, int _y)
	{
		isObstacle = obstacle;
		pos = p;
		x = _x;
		y = _y;
	}

}
