using UnityEngine;
using System.Collections;

//<summary>
//Basic class for maze generation logic
//</summary>
public abstract class BasicMazeGenerator {
	public int RowCount{ get{ return mMazeRows; } }
	public int ColumnCount { get { return mMazeColumns; } }

	// private instances
	private int mMazeRows;
	private int mMazeColumns;
	private MazeCell[,] mMaze;

	public BasicMazeGenerator(int rows, int columns){
		mMazeRows = Mathf.Abs(rows);
		mMazeColumns = Mathf.Abs(columns);
		// ensure that the maze has at least one row
		if (mMazeRows == 0) {
			mMazeRows = 1;
		}
		// ensure that the maze has at least one column
		if (mMazeColumns == 0) {
			mMazeColumns = 1;
		}
		// for loop for generating the maze cells 
		mMaze = new MazeCell[rows,columns];
		for (int row = 0; row < rows; row++) {
			for(int column = 0; column < columns; column++){
				mMaze[row,column] = new MazeCell();
			}
		}
	}

	public abstract void GenerateMaze();

	// method for selecting maze cell
	public MazeCell GetMazeCell(int row, int column){
		if (row >= 0 && column >= 0 && row < mMazeRows && column < mMazeColumns) {
			return mMaze[row,column];
		}else{
			// save that the maze cell was not found
			Debug.Log(row+" "+column);
			throw new System.ArgumentOutOfRangeException();
		}
	}

	// method for giving maze cell a specific value
	protected void SetMazeCell(int row, int column, MazeCell cell){
		if (row >= 0 && column >= 0 && row < mMazeRows && column < mMazeColumns) {
			mMaze[row,column] = cell;
		}else{
			throw new System.ArgumentOutOfRangeException();
		}
	}
}
