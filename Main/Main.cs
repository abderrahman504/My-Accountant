using Godot;
using System;

public class Main : Control
{
	public override void _Ready()
	{
		GetNode<Control>("CategoryCreator").Connect("categories_updated", this, "on_categories_updated");
	}

	void open_category_creator()
	{
		GetNode<WindowDialog>("CategoryCreator").Show();
	}

	void on_categories_updated()
	{
		GlobRefs.recDisplay.update_category_list();
	}
}
