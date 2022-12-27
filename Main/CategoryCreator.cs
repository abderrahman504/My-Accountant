using Godot;
using System;

public class CategoryCreator : WindowDialog
{
	[Signal]
	delegate void categories_updated();

    public override void _Ready()
    {
        
    }

	public void add_category()
	{
		String name = GetNode<LineEdit>("LineEdit").Text;
		if (name.Length != 0)
		{
			int searchResult = GlobRefs.categories.BinarySearch(name);
			if (searchResult < 0)
			{
				GlobRefs.categories.Add(name);
				EmitSignal("categories_updated");
			}
			else
			{
				ErrorLabel errorMsg = new ErrorLabel("Category already exists");
				GetNode<VBoxContainer>("VBoxContainer").AddChild(errorMsg);	
			}
		}
		else
		{
			ErrorLabel errorMsg = new ErrorLabel("You didn't specify a name");
			GetNode<VBoxContainer>("VBoxContainer").AddChild(errorMsg);
		}
	}

}
