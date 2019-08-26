using Godot;
using System;

public class DamageBox : Area2D
{
    void OnBodyEntered(PhysicsBody2D body2D){
        if (body2D is Player){
            Player player = body2D as Player;
            player.GetNode<AudioStreamPlayer2D>("PainSFX").Play();
            player.LifeMath(-1);
            player.damageFlash = true;
        }
    }

    void OnBodyExited(PhysicsBody2D body2D){
        if (body2D is Player){
            Player player = body2D as Player;
            player.damageFlash = false;
            player.Visible = true;
        }
    }
}
