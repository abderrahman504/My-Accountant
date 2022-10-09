using Godot;
using System;

public class Main : Control
{
	public override void _Ready()
	{
		
	}

	void open_category_creator()
	{
		GetNode<WindowDialog>("CategoryCreator").Show();
	}

}
