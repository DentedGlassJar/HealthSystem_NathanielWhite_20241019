using JetBrains.Annotations;
using System;
public class HealthSystem
{
    // Variables
    public int health;
    public string healthStatus;
    public int shield;
    public int lives;
    public bool isShieldUp;

    // Optional XP system variables
    public int xp;
    public int level;

    public HealthSystem()
    {
        ResetGame();
    }


    public string ShowHUD()
    {
        // Implement HUD display
        return $"Health: {health} | Shield: {shield} | Lives: {lives}";
    }

    public void TakeDamage(int damage)
    {
        // Implement damage logic
        if (isShieldUp == true)
        {
            shield = shield - damage;

            if (shield <= 0)
            {
                isShieldUp = false;
                shield = 0;
            }
        }
        else
        {
            health = health - damage;

            if(health <= 0)
            {
                health = 0;
            }
        }
    }

    public void Heal(int hp)
    {
        // Implement healing logic
    }

    public void RegenerateShield(int hp)
    {
        // Implement shield regeneration logic
    }

    public void Revive()
    {
        // Implement revive logic
    }

    public void ResetGame()
    {
        // Reset all variables to default values
        health = 100;
        shield = 100;
        lives = 3;
        isShieldUp = true;
    }

    // Optional XP system methods
    public void IncreaseXP(int exp)
    {
        // Implement XP increase and level-up logic
    }
}