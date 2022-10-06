using Godot;
using System;

public class RecordsDisplay : PanelContainer
{
    
    public override void _Ready()
    {
        
    }

    void add_record()
    {
		PackedScene x = (PackedScene)(GD.Load(GlobRefs.recordPath));
		Record newRecord = (Record)x.Instance();
		VBoxContainer child = GetNode<VBoxContainer>("VBoxContainer");
		child.AddChild(newRecord);
		child.MoveChild(child.GetNode<Button>("AddRecord"), child.GetChildCount()-1);
		
    }
}
