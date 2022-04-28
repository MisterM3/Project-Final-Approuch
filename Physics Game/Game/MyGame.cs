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

	CollectableSystem CS;
	HUD _hud;

	public List<Ball> _movers;
	List<LineSegment> _lines;
//	List<Enemy2Way> _enemy2Ways = new List<Enemy2Way>();
	Collectable[] _colect = new Collectable[3];
	

	EndCircle _endCircle;

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
		cannon = new Cannon(height / 2 - 275, width / 2 + 50 - 150, 10);
		AddChild(cannon);


		LoadScene(_startSceneNumber);

		PrintInfo();


		CS = new CollectableSystem();
		AddChild(CS);
		CS.LoadStars();
		CS.PrintStars();

		_hud = new HUD(new Vec2(200, 200));
		AddChild(_hud);

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

	public int GetCurrentScene 
	{ 
	get { return currentScene; }
	}

	public CollectableSystem GetCollectableSystem { 
		get { return CS; }
	}
	public HUD GetHUD { 
		get { return _hud; }
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
		for (int i = 0; i < _colect.Length; i++) {

			if (_colect[i] != null) _colect[i].Destroy();
		}
		//foreach (Enemy2Way en in _enemy2Ways) 
		//{
		//	en.Destroy();
		//}
		if (_endCircle != null) _endCircle.LateDestroy();
		

		_lines.Clear();

		switch (sceneNumber)
        {

			case 1: // Main Menu

			break;

			case 2: // Level1
				currentScene = 2;
			
			

				//Outer walls
				_lines.Add(new LineSegment(new Vec2(50, 50), new Vec2(750, 50)));
				_lines.Add(new LineSegment(new Vec2(750, 50), new Vec2(750, 550)));
				_lines.Add(new LineSegment(new Vec2(750, 550), new Vec2(50, 550)));
				_lines.Add(new LineSegment(new Vec2(50, 550), new Vec2(50, 50)));

				//_movers.Add(new Ball(10, new Vec2(100, 250), new Vec2(0, 10)));



				//Bottom left part
				_lines.Add(new LineSegment(new Vec2(200, 375), new Vec2(50, 375)));
				_lines.Add(new LineSegment(new Vec2(225, 550), new Vec2(225,400)));
				_movers.Add(new Ball(25, new Vec2(200, 400), moving: false));

				_lines.Add(new LineSegment(new Vec2(750, 540), new Vec2(225, 480)));



				//Side lines
				_lines.Add(new LineSegment(new Vec2(0, 200), new Vec2(200, 0)));
				_lines.Add(new LineSegment(new Vec2(600, 0), new Vec2(800, 200)));
				_lines.Add(new LineSegment(new Vec2(200, 0), new Vec2(0, 200)));
				_lines.Add(new LineSegment(new Vec2(800, 400), new Vec2(600, 600)));



				//Middle part

				_lines.Add(new LineSegment(new Vec2(590, 420), new Vec2(585, 200)));
				_lines.Add(new LineSegment(new Vec2(515, 200), new Vec2(530, 420)));

				_movers.Add(new Ball(35, new Vec2(550, 200), moving: false));
				_movers.Add(new Ball(30, new Vec2(560, 420), moving: false));

				//Collectables
			
				_colect[0] = new Collectable(30, new Vec2(460, 123));
				_colect[1] = new Collectable(30, new Vec2(422, 452));
				_colect[2] = new Collectable(30, new Vec2(660, 293));


				//Enemy
				 _movers.Add( new Enemy2Way(10, new Vec2(627, 220), new Vec2(705, 220)) );

				ChangeSpeedPad csp = new ChangeSpeedPad(new Vec2(240, 130), 60, 40, pSpeed: 0.5f);
				AddChild(csp);

				break;

			case 3: // Level2 
				currentScene = 3;

				Fan fan = new Fan(new Vec2(400, 300), 100, 100);
				AddChild(fan);

				Collectable col4 = new Collectable(30, new Vec2(400, 300));
				AddChild(col4);

				_endCircle = new EndCircle(new Vec2(400, 300));
				AddChild(_endCircle);

				Clouds cloud = new Clouds(new Vec2(100, 200), new Vec2(200, 200), new Vec2(100, 100), new Vec2(200, 100));
				AddChild(cloud);


			break;

			case 4: //End screen
				currentScene = 4;
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
		foreach (Collectable _col in _colect) 
		{
			AddChild(_col);
		}
		//foreach (Enemy2Way en in _enemy2Ways)
		//{
		//	AddChild(en);
		//}

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

        if (Input.GetMouseButtonDown(1)) Console.WriteLine(new Vec2(Input.mouseX, Input.mouseY));
        //Load/reset scenes:
        if (Input.GetKeyDown(Key.R))
        {
			LoadScene(currentScene);
			CS.RestartStarsLevel();
			cannon.shots = 2;
        }

        if (Input.GetKeyDown(Key.F1))
        {
			LoadScene(2);
			CS.RestartStarsLevel();
		}

        if (Input.GetKeyDown(Key.F2))
        {
			LoadScene(3);
			CS.RestartStarsLevel();
		}
	}

	public void NextLevel() { 
	
	LoadScene(currentScene + 1);
	}


	public void addMover(Ball ball)
	{
		_movers.Add(ball);
	}

	public void addLine(LineSegment line) { 
		_lines.Add(line);
	}

	public void RemoveLine(LineSegment line) {
		_lines.Remove(line);
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