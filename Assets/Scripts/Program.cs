using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
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

        if(health <= 100 && health >= 91)
        {
            healthStatus = "Perfectly Healthy";
        }
        else if(health <= 90 && health >= 76)
        {
            healthStatus = "Healthy";
        }
        else if(health <= 75 && health >= 51)
        {
            healthStatus = "Hurt";
        }
        else if(health <= 50 && health >= 11)
        {
            healthStatus = "Badly Hurt";
        }
        else if(health <= 10 && health >= 1)
        {
            healthStatus = "Imminent Danger";
        }

        return $"Health: {health} | {healthStatus} | Shield: {shield} | Lives: {lives}";
    }

    public void TakeDamage(int damage)
    {
        // Implement damage logic
        if (isShieldUp == true)
        {
            shield = shield - damage;

            if (shield <= 0)
            {
                health = health - Math.Abs(shield);
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

        if(health <= 0 && lives != 0)
        {
            Revive();
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
        health = 100;
        shield = 100;
        lives = lives - 1;
        isShieldUp = true;

        if(lives == 0)
        {
            health = 0;
            shield = 0;
            lives = 0;
        }
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