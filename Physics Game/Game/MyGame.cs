using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;

public class MyGame : Game
{
	int _startSceneNumber = 0;

	

	Canvas _lineContainer = null;

	List<Ball> _movers;
	List<LineSegment> _lines;


	public int GetNumberOfLines()
	{
		return _lines.Count;
	}

	public LineSegment GetLine(int index)
	{
		if (index >= 0 && index < _lines.Count)
		{
			return _lines[index];
		}
		return null;
	}

	public int GetNumberOfMovers()
	{
		return _movers.Count;
	}

	public Ball GetMover(int index)
	{
		if (index >= 0 && index < _movers.Count)
		{
			return _movers[index];
		}
		return null;
	}

	public void DrawLine(Vec2 start, Vec2 end)
	{
		_lineContainer.graphics.DrawLine(Pens.White, start.x, start.y, end.x, end.y);
	}


	public MyGame() : base(800, 600, false, false)
	{
	//	UnitTesting ut = new UnitTesting();

		_lineContainer = new Canvas(width, height);
		AddChild(_lineContainer);

		targetFps = 60;

		_movers = new List<Ball>();
		_lines = new List<LineSegment>();

		

		PrintInfo();

		Ball ball = new Ball(30, new Vec2(100, 300), new Vec2(1, 0));
		addMover(ball);
		AddChild(ball);
		Powers pow = new Powers(new Vec2(200, 300));
		AddChild(pow);

	}

	void AddLine(Vec2 start, Vec2 end)
	{
		LineSegment line = new LineSegment(start, end, 0xff00ff00, 4);
		AddChild(line);
		_lines.Add(line);
	}



	/****************************************************************************************/

	void PrintInfo()
	{
		Console.WriteLine("Hold tab to slow down the frame rate.");
		Console.WriteLine("Press R to reset scene");
		Console.WriteLine("Press B to toggle high/low bounciness.");
	}

	void HandleInput()
	{


		targetFps = Input.GetKey(Key.TAB) ? 5 : 60;

		if (Input.GetKeyDown(Key.B))
		{
			Ball.bounciness = 1.5f - Ball.bounciness;
		}
		
	}


	public void addMover(Ball ball)
	{
		_movers.Add(ball);
	}



	public void RemoveBalls(Ball remove)
	{

		_movers.Remove(remove);
	}


	void Update()
	{
		HandleInput();
	}

	static void Main()
	{
		new MyGame().Start();
	}



}