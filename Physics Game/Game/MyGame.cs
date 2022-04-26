using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;

public class MyGame : Game
{
	int _startSceneNumber = 2;
	int currentScene = 0;
	int totalLevels = 5;
	

	Canvas _lineContainer = null;

	public Cannon cannon;

	public List<Ball> _movers;
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

		//Cannon
		cannon = new Cannon(height / 2 - 200, width / 2 + 50, 2);
		AddChild(cannon);


		LoadScene(_startSceneNumber);

		PrintInfo();


		CollectableSystem CS = new CollectableSystem();
		AddChild(CS);
		CS.LoadStars();
		CS.PrintStars();
	//	CS.CheckStars(1, 3);
	//	CS.CheckStars(2, 5);
	}

	void AddLine(Vec2 start, Vec2 end)
	{
		LineSegment line = new LineSegment(start, end, 0xff00ff00, 4);
		AddChild(line);
		_lines.Add(line);
	}

	public int GetLevelCount
	{
		get { return totalLevels; }
	}

	/****************************************************************************************/

	void LoadScene(int sceneNumber)
    {
		foreach (Ball ball in _movers)
		{
			ball.Destroy();
		}
		_movers.Clear();
		foreach (LineSegment line in _lines)
        {
			line.Destroy();
        }
		_lines.Clear();

		switch (sceneNumber)
        {

			case 1: // Main Menu

			break;

			case 2: // Level1
				currentScene = 2;
				_lines.Add(new LineSegment(100, 200, 400, 200, 0xff00ff00, 3));

				Enemy2Way enemy = new Enemy2Way(30, new Vec2(400, 300), new Vec2(300, 200), new Vec2(500, 400));
				AddChild(enemy);
			break;

			case 3: // Level2 
				currentScene = 3;
				_lines.Add(new LineSegment(200, 400, 500, 400, 0xff00ff00, 3));
			break;

			case 4: //End screen

			break;
        }
		foreach (Ball _ball in _movers)
        {
			AddChild(_ball);
        }

		foreach(LineSegment _line in _lines)
        {
			AddChild(_line);
        }

    }

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

        //Load/reset scenes:
        if (Input.GetKeyDown(Key.R))
        {
			LoadScene(currentScene);
        }

        if (Input.GetKeyDown(Key.F1))
        {
			LoadScene(2);
        }

        if (Input.GetKeyDown(Key.F2))
        {
			LoadScene(3);
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