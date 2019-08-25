using Godot;
using System;

public class PassageLabel : Label
{
    void OnPassageHit(string label){
        Text = label;
        Show();
    }
}
