//LMSC-281 Logic and Programming
//adopted from http://stackoverflow.com/questions/26147958/creating-a-tiled-map-in-unity-using-a-2d-array-and-a-text-file
//Fall 2016 Jeanine Cowen

//include libraries
using UnityEngine;
using System.Collections;
using System.IO;

public class LoadMap : MonoBehaviour {

	int X, Y;						//used to hold the position of the map piece
	public int mapHeight;			//this allows for the map to define the number of rows
	public int mapWidth;			//this allows for the map to define the number of columns
	const int numOfTileTypes = 8;	//since this is the size of an array, it must be a constant


	GameObject mapTile;				//this holds each tile to be created
	
	GameObject [,] mapArray;		//this will hold the entire map

	public GameObject [] Tiles = new GameObject[numOfTileTypes]; //this is an array of the tile objects


	// Use this for initialization
	void Start () {
		BuildMap ();
	}

	void BuildMap(){
		
		bool isMap = false;
		string input = File.ReadAllText(Application.dataPath + "/Resources/Maps/map00.txt");

		mapHeight = 1;	//we only need to take in one position at a time for the height and width
		mapWidth = 1;

		mapArray = new GameObject [mapHeight,mapWidth];
		
		string[] fromFile = input.Split(new string[] {"\n", "\r", "\r\n"},  
		System.StringSplitOptions.RemoveEmptyEntries);	//this removes the non-map characters from the row of text
		
		if(fromFile[0].Length > 0 && fromFile[1].Length > 0) {
			int.TryParse(fromFile[0], out mapHeight);	//parse the first line of text in the file to an integer for the mapHeight
			int.TryParse(fromFile[1], out mapWidth);	//parse the 2nd text line to an int for the mapWidth
		}

		//now that we have loaded the custom map width and height, we can process the tile positions
		
		if (mapWidth > 0 && mapHeight > 0) {	//check to make sure there are valid height and width numbers
			mapArray = new GameObject [mapHeight, mapWidth];	//create a new array to hold the map tile information
			int y = 0, x = 0;	//set the process to start at the beginning


			//this topmost nested foreach loop will load a full row
			foreach (string row in input.Split('\n')) {
				
				x = 0;

				//this inner foreach loop processes the characters in the columns
				foreach (string col in row.Trim().Split(' ')) {

					//this is the code that places the prefabs as associated with the numbers in the map file into the game environment
					if(int.Parse (col.Trim ()) < numOfTileTypes){
						mapArray [y, x] = Tiles [int.Parse (col.Trim ())];  
						mapTile = mapArray [y, x];
						GameObject.Instantiate (mapTile, new Vector3 (x, mapHeight-y, 0), Quaternion.Euler (0, 0, 0));
						x++;
						isMap = true;
					}
					else{ 
						isMap = false; 
					}
				}
				if(isMap == true){ y++; }
			}
		}
	}
}
