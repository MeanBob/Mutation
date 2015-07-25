using UnityEngine;
using System.Collections;

public class ExplorationImage  : ScriptableObject
{
	
	public string[,] backgroundImage =  new string[10, 11];
	
	public void Start()
	{
		//A row
		backgroundImage[0,0] = "Backgrounds/CastleWallTest";
		backgroundImage[1,0] = "Backgrounds/CastleWallTest";
		backgroundImage[2,0] = "Backgrounds/CastleWallTest";
		backgroundImage[3,0] = "Backgrounds/CastleWallTest";
		backgroundImage[4,0] = "Backgrounds/CastleWallTest";
		backgroundImage[5,0] = "Backgrounds/CastleWallTest";
		backgroundImage[6,0] = "Backgrounds/CastleWallTest";
		backgroundImage[7,0] = "Backgrounds/ForestPath";
		backgroundImage[8,0] = "Backgrounds/CastleWallTest";
		backgroundImage[9,0] = "Backgrounds/CastleWallTest";
		//B row
		backgroundImage[0,1] = "Backgrounds/CastleWallTest";
		backgroundImage[1,1] = "Backgrounds/CastleWallTest";
		backgroundImage[2,1] = "Backgrounds/CastleWallTest";
		backgroundImage[3,1] = "Backgrounds/CastleWallTest";
		backgroundImage[4,1] = "Backgrounds/ForestPath";
		backgroundImage[5,1] = "Backgrounds/ForestPath";
		backgroundImage[6,1] = "Backgrounds/ForestPath";
		backgroundImage[7,1] = "Backgrounds/ForestPath";
		backgroundImage[8,1] = "Backgrounds/CastleWallTest";
		backgroundImage[9,1] = "Backgrounds/CastleWallTest";
		//C row
		backgroundImage[0,2] = "Backgrounds/CastleWallTest";
		backgroundImage[1,2] = "Backgrounds/CastleWallTest";
		backgroundImage[2,2] = "Backgrounds/CastleWallTest";
		backgroundImage[3,2] = "Backgrounds/CastleWallTest";
		backgroundImage[4,2] = "Backgrounds/ForestPath";
		backgroundImage[5,2] = "Backgrounds/CastleWallTest";
		backgroundImage[6,2] = "Backgrounds/CastleWallTest";
		backgroundImage[7,2] = "Backgrounds/CastleWallTest";
		backgroundImage[8,2] = "Backgrounds/CastleWallTest";
		backgroundImage[9,2] = "Backgrounds/CastleWallTest";
		//D row
		backgroundImage[0,3] = "Backgrounds/CastleWallTest";
		backgroundImage[1,3] = "Backgrounds/CastleWallTest";
		backgroundImage[2,3] = "Backgrounds/CastleWallTest";
		backgroundImage[3,3] = "Backgrounds/CastleWallTest";
		backgroundImage[4,3] = "Backgrounds/ForestPath";
		backgroundImage[5,3] = "Backgrounds/CastleWallTest";
		backgroundImage[6,3] = "Backgrounds/CastleWallTest";
		backgroundImage[7,3] = "Backgrounds/CastleWallTest";
		backgroundImage[8,3] = "Backgrounds/CastleWallTest";
		backgroundImage[9,3] = "Backgrounds/CastleWallTest";
		//E row
		backgroundImage[0,4] = "Backgrounds/CastleWallTest";
		backgroundImage[1,4] = "Backgrounds/CastleWallTest";
		backgroundImage[2,4] = "Backgrounds/CastleWallTest";
		backgroundImage[3,4] = "Backgrounds/CastleWallTest";
		backgroundImage[4,4] = "Backgrounds/ForestPath";
		backgroundImage[5,4] = "Backgrounds/CastleWallTest";
		backgroundImage[6,4] = "Backgrounds/CastleWallTest";
		backgroundImage[7,4] = "Backgrounds/CastleWallTest";
		backgroundImage[8,4] = "Backgrounds/CastleWallTest";
		backgroundImage[9,4] = "Backgrounds/CastleWallTest";
		//F Row
		backgroundImage[0,5] = "Backgrounds/CastleWallTest";
		backgroundImage[1,5] = "Backgrounds/CastleWallTest";
		backgroundImage[2,5] = "Backgrounds/ForestPath";
		backgroundImage[3,5] = "Backgrounds/ForestPath";
		backgroundImage[4,5] = "Backgrounds/ForestPath";
		backgroundImage[5,5] = "Backgrounds/ForestPath";
		backgroundImage[6,5] = "Backgrounds/ForestPath";
		backgroundImage[7,5] = "Backgrounds/ForestPath";
		backgroundImage[8,5] = "Backgrounds/ForestPath";
		backgroundImage[9,5] = "Backgrounds/CastleWallTest";
		//G row
		backgroundImage[0,6] = "Backgrounds/CastleWallTest";
		backgroundImage[1,6] = "Backgrounds/CastleWallTest";
		backgroundImage[2,6] = "Backgrounds/ForestPath";
		backgroundImage[3,6] = "Backgrounds/CastleWallTest";
		backgroundImage[4,6] = "Backgrounds/CastleWallTest";
		backgroundImage[5,6] = "Backgrounds/CastleWallTest";
		backgroundImage[6,6] = "Backgrounds/CastleWallTest";
		backgroundImage[7,6] = "Backgrounds/ForestPath";
		backgroundImage[8,6] = "Backgrounds/CastleWallTest";
		backgroundImage[9,6] = "Backgrounds/CastleWallTest";
		//H row
		backgroundImage[0,7] = "Backgrounds/ForestPath";
		backgroundImage[1,7] = "Backgrounds/ForestPath";
		backgroundImage[2,7] = "Backgrounds/ForestPath";
		backgroundImage[3,7] = "Backgrounds/CastleWallTest";
		backgroundImage[4,7] = "Backgrounds/CastleWallTest";
		backgroundImage[5,7] = "Backgrounds/CastleWallTest";
		backgroundImage[6,7] = "Backgrounds/CastleWallTest";
		backgroundImage[7,7] = "Backgrounds/ForestPath";
		backgroundImage[8,7] = "Backgrounds/CastleWallTest";
		backgroundImage[9,7] = "Backgrounds/CastleWallTest";
		//I row
		backgroundImage[0,8] = "Backgrounds/CastleWallTest";
		backgroundImage[1,8] = "Backgrounds/CastleWallTest";
		backgroundImage[2,8] = "Backgrounds/CastleWallTest";
		backgroundImage[3,8] = "Backgrounds/CastleWallTest";
		backgroundImage[4,8] = "Backgrounds/CastleWallTest";
		backgroundImage[5,8] = "Backgrounds/CastleWallTest";
		backgroundImage[6,8] = "Backgrounds/CastleWallTest";
		backgroundImage[7,8] = "Backgrounds/ForestPath";
		backgroundImage[8,8] = "Backgrounds/ForestPath";
		backgroundImage[9,8] = "Backgrounds/CastleWallTest";
		//J row
		backgroundImage[0,9] = "Backgrounds/CastleWallTest";
		backgroundImage[1,9] = "Backgrounds/CastleWallTest";
		backgroundImage[2,9] = "Backgrounds/CastleWallTest";
		backgroundImage[3,9] = "Backgrounds/CastleWallTest";
		backgroundImage[4,9] = "Backgrounds/CastleWallTest";
		backgroundImage[5,9] = "Backgrounds/CastleWallTest";
		backgroundImage[6,9] = "Backgrounds/CastleWallTest";
		backgroundImage[7,9] = "Backgrounds/CastleWallTest";
		backgroundImage[8,9] = "Backgrounds/ForestPath";
		backgroundImage[9,9] = "Backgrounds/CastleWallTest";
		//K Row
		backgroundImage[0,10] ="Backgrounds/CastleWallTest";
		backgroundImage[1,10] ="Backgrounds/CastleWallTest";
		backgroundImage[2,10] ="Backgrounds/CastleWallTest";
		backgroundImage[3,10] ="Backgrounds/CastleWallTest";
		backgroundImage[4,10] ="Backgrounds/CastleWallTest";
		backgroundImage[5,10] ="Backgrounds/CastleWallTest";
		backgroundImage[6,10] ="Backgrounds/CastleWallTest";
		backgroundImage[7,10] ="Backgrounds/CastleWallTest";
		backgroundImage[8,10] ="Backgrounds/ForestPath";
		backgroundImage[9,10] ="Backgrounds/CastleWallTest";
		
		
	}
	
	
}
