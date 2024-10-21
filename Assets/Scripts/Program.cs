using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;
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

        if (health <= 100 && health >= 91)
        {
            healthStatus = "Perfectly Healthy";
        }
        else if (health <= 90 && health >= 76)
        {
            healthStatus = "Healthy";
        }
        else if (health <= 75 && health >= 51)
        {
            healthStatus = "Hurt";
        }
        else if (health <= 50 && health >= 11)
        {
            healthStatus = "Badly Hurt";
        }
        else if (health <= 10 && health >= 1)
        {
            healthStatus = "Imminent Danger";
        }

        return $"Health: {health} | {healthStatus} | Shield: {shield} | Lives: {lives} | Level: {level} | XP: {xp} / 100";
    }

    public void TakeDamage(int damage)
    {
        // Implement damage logic
        if (isShieldUp == true)
        {
            shield = shield - Math.Abs(damage);

            if (shield <= 0)
            {
                health = health - Math.Abs(shield);
                isShieldUp = false;
                shield = 0;
            }
        }
        else
        {
            health = health - Math.Abs(damage);

            if (health <= 0)
            {
                health = 0;
            }
        }

        if (health <= 0 && lives != 0)
        {
            Revive();
        }
    }

    public void Heal(int hp)
    {
        // Implement healing logic
        health += Math.Abs(hp);

        if (health >= 100)
        {
            health = 100;
        }
    }

    public void RegenerateShield(int hp)
    {
        // Implement shield regeneration logic
        shield += Math.Abs(hp);

        if (shield >= 100)
        {
            shield = 100;
        }
    }

    public void Revive()
    {
        // Implement revive logic
        health = 100;
        shield = 100;
        lives = lives - 1;
        isShieldUp = true;

        if (lives == 0)
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
        xp = 0;
        level = 1;
        isShieldUp = true;
    }

    public static void AllUnitTests()
    {
        DamageShieldOnly();
        DamageBoth();
        DamageHealthOnly();
        ReduceHealthToZero();
        ReduceBothToZero();
        NegativeDamageInput();

        NormalHealing();
        MaxHeal();
        NegativeHealInput();

        NormalShieldRegen();
        MaxShield();
        NegativeShieldInput();

        ReviveTest();
    }

    public static void DamageShieldOnly()
    {
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.health = 100;
        system.lives = 3;

        system.TakeDamage(10);

        Debug.Assert(90 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(3 == system.lives);
    }

    public static void DamageBoth()
    {
        HealthSystem system = new HealthSystem();

        system.TakeDamage(110);

        Debug.Assert(0 == system.shield);
        Debug.Assert(90 == system.health);
        Debug.Assert(3 == system.lives);
    }

    public static void DamageHealthOnly()
    {
        HealthSystem system = new HealthSystem();

        system.shield = 0;
        system.TakeDamage(10);

        Debug.Assert(0 == system.shield);
        Debug.Assert(90 == system.health);
        Debug.Assert(3 == system.lives);
    }

    public static void ReduceHealthToZero()
    {
        HealthSystem system = new HealthSystem();

        system.shield = 0;
        system.TakeDamage(100);

        Debug.Assert(100 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(2 == system.lives);
    }
    
    public static void ReduceBothToZero()
    {
        HealthSystem system = new HealthSystem();

        system.TakeDamage(200);

        Debug.Assert(100 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(2 == system.lives);
    }

    public static void NegativeDamageInput()
    {
        HealthSystem system = new HealthSystem();

        system.TakeDamage(-10);

        Debug.Assert(90 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(3 == system.lives);
    }

    public static void NormalHealing()
    {
        HealthSystem system = new HealthSystem();

        system.health = 80;
        system.Heal(20);

        Debug.Assert(100 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(3 == system.lives);
    }

    public static void MaxHeal()
    {
        HealthSystem system = new HealthSystem();

        system.Heal(20);

        Debug.Assert(100 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(3 == system.lives);
    }

    public static void NegativeHealInput()
    {
        HealthSystem system = new HealthSystem();

        system.Heal(-20);

        Debug.Assert(100 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(3 == system.lives);
    }

    public static void NormalShieldRegen()
    {
        HealthSystem system = new HealthSystem();

        system.shield = 80;
        system.RegenerateShield(20);

        Debug.Assert(100 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(3 == system.lives);
    }

    public static void MaxShield()
    {
        HealthSystem system = new HealthSystem();

        system.RegenerateShield(20);

        Debug.Assert(100 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(3 == system.lives);
    }

    public static void NegativeShieldInput()
    {
        HealthSystem system = new HealthSystem();

        system.RegenerateShield(-20);

        Debug.Assert(100 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(3 == system.lives);
    }

    public static void ReviveTest()
    {
        HealthSystem system = new HealthSystem();

        system.TakeDamage(200);
        
        Debug.Assert(100 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(2 == system.lives);
    }

    // Optional XP system methods
    public void IncreaseXP(int exp)
    {
        // Implement XP increase and level-up logic
        xp = xp + exp;

        if (xp >= 100)
        {
            level++;
            xp = 0;
        }

        if(level == 100)
        {
            level = 0;
        }
    }
}