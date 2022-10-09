using Godot;
using System;

public class RecordsDisplay : PanelContainer
{
	
	public override void _Ready()
	{

		GlobRefs.recDisplay = this;
		normalize_columns();

	}

	void add_record()
	{
		PackedScene x = (PackedScene)(GD.Load(GlobRefs.recordPath));
		Record newRecord = (Record)x.Instance();
		VBoxContainer child = GetNode<VBoxContainer>("VBoxContainer");
		child.AddChild(newRecord);
		child.MoveChild(child.GetNode<Button>("AddRecord"), child.GetChildCount()-1);
		normalize_columns();
	}

	public void delete_record(Record record)
	{
		record.QueueFree();
		normalize_columns();
	}

	public void normalize_columns()
	{
		minimize_column_widths();
		SceneTreeTimer timer = GetTree().CreateTimer(0.01f);
		timer.Connect("timeout", this, "fix_column_widths");
	} 

	private void minimize_column_widths()
	{
		GD.Print("Minimizing");
		Godot.Collections.Array rows = GetNode<VBoxContainer>("VBoxContainer").GetChildren(); 
		for (int i=1; i < rows.Count-1; i++)
		{
			Record record = (Record) rows[i];
			Godot.Collections.Array recElements = record.GetChildren();
			for (int j=0; j < recElements.Count-1; j++)
			{
				PanelContainer element = (PanelContainer) recElements[j];
				element.RectMinSize = new Vector2(50, 0);
			}
			((Control)recElements[0]).RectMinSize = new Vector2(102, 0);
			((Control)recElements[1]).RectMinSize = new Vector2(127, 0);
		}
	}

	private void fix_column_widths()
	{
		float[] maxWidths = new float[5];
		
		Godot.Collections.Array rows = GetNode<VBoxContainer>("VBoxContainer").GetChildren(); 
		for (int i=1; i < rows.Count-1; i++) //Getting the max widths in each column.
		{
			Record record = (Record) rows[i];
			Godot.Collections.Array recElements = record.GetChildren();
			for (int j=0; j < recElements.Count-1; j++)
			{
				PanelContainer element = (PanelContainer) recElements[j];
				if (maxWidths[j] < element.RectSize.x) maxWidths[j] = element.RectSize.x;
			}
		}
		//Setting the min size of each cell in a column according to maxWidths
		for (int i=0; i < rows.Count-1; i++)
		{
			HBoxContainer row = (HBoxContainer) rows[i];
			Godot.Collections.Array rowElements = row.GetChildren();
			for (int j=0; j < rowElements.Count-1; j++)
			{
				Control element = (Control) rowElements[j];
				element.RectMinSize = new Vector2(maxWidths[j], 0);
			}
		}
	}

	/*
	Normalizing columns is a two stage process with a pause in-between. 
	First, minimize columns (funcion available).
	Second, find the maximum width and set the column length to that (function available. Needs to be renamed).
	*/
}
