using Godot;
using System;
using System.Text;

public class Record : HBoxContainer
{
	decimal amount;
	DateTime date;
	String category;
	String name;
	String note;
	
	public override void _Ready()
	{
		date = DateTime.Now;
		Label dateLabel = GetNode<Label>("Date/Label");
		dateLabel.Text = date.Day + "-" + date.Month + "-" + date.Year;
	}

	void delete()
	{
		GlobRefs.recDisplay.delete_record(this);
	}

	void record_changed()
	{
		GlobRefs.recDisplay.normalize_columns();
	}

	void on_name_changed(String txt)
	{
		record_changed();
	}

	void on_amount_changed(String txt)
	{
		record_changed();
	}

	void on_category_changed(int index)
	{
		record_changed();
	}

}

