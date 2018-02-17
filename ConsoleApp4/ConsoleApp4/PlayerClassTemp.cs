﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class PlayerClassTemp
    {

        protected string sCharacterName; // Name of the character
        protected int iCharacterHealth; // Health of the character
        protected int iCharacterMaxHealth; // Max Health;
        protected int iMinimumDamage; // Minimum damage of player                                                                   // Rand(iMinimumDamage,iMaximumDamage);
        protected int iMaximumDamage; // Maximum damage of player
        protected int iPlayerDodgeValue; // Dodge value of player
        protected int iPlayerAccuracy; // Hit chance of player
        Random rRNGesus = new Random();

        public string Name
        {
            get
            {
                return sCharacterName;
            }

            set
            {
                sCharacterName = value;

                if (sCharacterName.Length == 0 || sCharacterName == null)
                {
                    sCharacterName = "Sir Montgomery Alexander Massachusetts Maximilian Finnegan Rasuuuuumus Hård";
                }
            }
        }

        public int Health
        {
            get
            {
                return iCharacterHealth;
            }

            set
            {
                iCharacterHealth = value;

                if (iCharacterHealth <= 0)
                {
                    iCharacterHealth = 0;
                    //Call death function
                }

                else if (iCharacterHealth > iCharacterMaxHealth)
                {
                    iCharacterHealth = iCharacterMaxHealth;
                    Console.WriteLine("You reached max health");
                }


            }
        }


        public bool PlayerAttack(int EnemyDodge)
        {
            int iTempAttackRoll = 0;
            iTempAttackRoll = rRNGesus.Next(1, 21);
            iTempAttackRoll = +iPlayerAccuracy;

            if (iTempAttackRoll >= EnemyDodge)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        public int PlayerDamage(bool PlayerAttack)
        {

            if (PlayerAttack)
            {
                return rRNGesus.Next(iMinimumDamage, ((iMaximumDamage + 1)));

            }

            else
            {
                return 0;
                Console.WriteLine("Missed");
            }
        }

        public bool PlayerDodge(int EnemyAttack)
        {
            int iTempDefendRoll = 0;
            iTempDefendRoll = rRNGesus.Next(1, 21);
            iTempDefendRoll =+ iPlayerDodgeValue;

            if (iTempDefendRoll >= EnemyAttack)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public void PlayerTakesDamage(bool PlayerDodge, int EnemyDamage)
        {
            if (PlayerDodge)
            {
                Console.WriteLine("Dodged");

            }

            else
            {
                Health -= EnemyDamage;
                Console.WriteLine("Taken {0} Damage", EnemyDamage);
            }
        }

        public int SpecialAttack()
        {
            return 0;
        }

        public int SpecicalAttack_2()
        {
            return 0;
        }


    }

    class Fat_Boi : PlayerClassTemp
    {
        public Fat_Boi(string InputName)
        {
           
        }


    }
}