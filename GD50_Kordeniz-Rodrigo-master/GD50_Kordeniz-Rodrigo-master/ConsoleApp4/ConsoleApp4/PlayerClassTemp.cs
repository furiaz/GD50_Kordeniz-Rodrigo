﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class PlayerClassTemp
    {

        public string sCharacterName; // Name of the character
        protected int iCharacterHealth; // Health of the character
        protected int iCharacterMaxHealth; // Max Health;
        protected int iMinimumDamage; // Minimum damage of player                                                                   
        protected int iMaximumDamage; // Maximum damage of player
        protected int iPlayerDodgeValue; // Dodge value of player
        protected int iPlayerAccuracy; // Hit chance of player
        protected Random rRNGesus = new Random(); // Rand(iMinimumDamage,iMaximumDamage);
        protected int iMana;
        protected int iMaxMana;
        protected int iDamage;
        public string Name
        {
            get
            {
                return sCharacterName;
            }

            set
            {
                sCharacterName = value;

                
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
                    Console.WriteLine("You reached max health.");
                }

                

            }
        }

        public int Mana
        {
            get
            {
                return iMana;
            }

            set
            {
                iMana = value;

                if (iMana <= 0)
                {
                    iMana = 0;
                    //Call death function
                }

                else if (iMana > iMaxMana)
                {
                    iMana = iMaxMana;
                    Console.WriteLine("You reached max mana.");
                }


            }
        }

        public int Dodge
        {
            get
            {
                return iPlayerDodgeValue;
            }

            set
            {
                iPlayerDodgeValue = value;
            }
        }

        public bool PlayerAttack(int EnemyDodge)
        {
            int iTempAttackRoll = 0;
            iTempAttackRoll = rRNGesus.Next(1, 7);
            iTempAttackRoll += iPlayerAccuracy;

            if (iTempAttackRoll >= EnemyDodge)
            {
                Console.WriteLine("Your attack will hit!.");
                return true;

            }

            else
            {
                Console.WriteLine("Sorry boi, your attack missed.");
                return false;

            }

        }

        public void PlayerDamage(bool PlayerAttack)
        {

            if (PlayerAttack)
            {
                iDamage = rRNGesus.Next(iMinimumDamage, ((iMaximumDamage + 1)));
                Console.WriteLine("You hitted the enemy for {0} damage", iDamage);
            }

            else
            {
                iDamage = 0;
                Console.WriteLine("Missed.");
            }
        }

        public bool PlayerDodge(int EnemyAttack)
        {
            int iTempDefendRoll = 0;
            iTempDefendRoll = +iPlayerDodgeValue;

            if (iTempDefendRoll >= EnemyAttack)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

       /* public void PlayerTakesDamage(bool PlayerDodge, int EnemyDamage)
        {
            if (PlayerDodge)
            {
                Console.WriteLine("Dodged.");

            }

            else
            {
                Health -= EnemyDamage;
                Console.WriteLine("Taken {0} Damage.", EnemyDamage);
            }
        }*/

        public virtual void SpecialAttack()
        {
            iDamage = 0;
        }

        public virtual void SpecicalAttack_2()
        {
            iDamage = 0;
        }

        public int AttackTemp(int PlayerInput, int EnemyDodge)
        {
            if ((PlayerInput == 2 || PlayerInput == 3) && iMana < 1)
            {
                Console.WriteLine("Not enough mana M'boi, using normal attack instead");
                PlayerInput = 1;
            }
            switch (PlayerInput)

            {
                case 1:
                    {
                        bool IsSuccess = PlayerAttack(EnemyDodge);
                        PlayerDamage(IsSuccess);
                        return iDamage;
                        break;
                    }
                case 2:
                    {
                        SpecialAttack();
                        return iDamage;
                        break;
                    }
                case 3:
                    {
                        SpecicalAttack_2();
                        return iDamage;
                        break;
                    }
                default:
                    return 0;
            }




        }

        public virtual void PrintChoices()
        {

        }


    }

    class Fat_Boi : PlayerClassTemp
    {
        public Fat_Boi(string InputName)
        {
            iCharacterHealth = 100;
            iCharacterMaxHealth = 100;
            iMinimumDamage = 10;
            iMaximumDamage = 16;
            iPlayerDodgeValue = 7;
            iPlayerAccuracy = 9;
            iMaxMana = 3;
            iMana = iMaxMana;
            sCharacterName = InputName;
        }

        public override void SpecialAttack()
        {
            Console.WriteLine("Fat Boi Special Smash!!!!!");
            iMana -= 1;
            iDamage = (Health / 5);
        }

        public override void SpecicalAttack_2()
        {
            Console.WriteLine("Fat Boi Ultimate Attack");
            iMana -= 1;
            iDamage = iMaximumDamage;
        }


    }

    class Stabby_Boi : PlayerClassTemp
    {
        public Stabby_Boi(string InputName)
        {
            iCharacterHealth = 50;
            iCharacterMaxHealth = 50;
            iMinimumDamage = 13;
            iMaximumDamage = 22;
            iPlayerDodgeValue = 10;
            iPlayerAccuracy = 11;
            iMaxMana = 4;
            iMana = iMaxMana;
            sCharacterName = InputName;
        }

        public override void SpecialAttack()
        {
            int iTempCrit = 0;
            iTempCrit = rRNGesus.Next(1, 7);
            iMana -= 1;

            if (iTempCrit > 4)
            {
                Console.WriteLine("Stabby boi critical stabby");
                iDamage = Convert.ToInt32(iMaximumDamage * 2.5);
            }

            else
            {
                Console.WriteLine("Critical stabby missed");
                iDamage = 0;
            }
        }

        public override void SpecicalAttack_2()
        {
            Console.WriteLine("Stabby boi secret move");
            iMana -= 1;
            iDamage = iPlayerDodgeValue + iPlayerAccuracy;
        }


    }
    class Wise_Boi : PlayerClassTemp
    {
        public Wise_Boi(string InputName)
        {
            iCharacterHealth = 50;
            iCharacterMaxHealth = 50;
            iMinimumDamage = 16;
            iMaximumDamage = 24;
            iPlayerDodgeValue = 4;
            iPlayerAccuracy = 6;
            iMaxMana = 5;
            iMana = iMaxMana;
            sCharacterName = InputName;
        }

        public override void SpecialAttack()
        {
            Console.WriteLine("Wise boi Arcane shot");
            iMana -= 1;
            int iSpellCount = 0;
            iSpellCount = rRNGesus.Next(1, 7);

            iDamage = Convert.ToInt32((iMinimumDamage / 3) * iSpellCount);
        }

        public override void SpecicalAttack_2()
        {
            Console.WriteLine("Wise boi mana bolt");
            iDamage = iMana * iMinimumDamage;
            iMana -= 1;
        }
        class Spooki_Boi : PlayerClassTemp
        {
            public Spooki_Boi(string InputName)
            {
                iCharacterHealth = 60;
                iCharacterMaxHealth = 60;
                iMinimumDamage = 10;
                iMaximumDamage = 25;
                iPlayerDodgeValue = 2;
                iPlayerAccuracy = 9;
                iMaxMana = 3;
                iMana = iMaxMana;
            }

            public override void SpecialAttack()
            {
                Health += 10;
                iDamage = rRNGesus.Next(iMinimumDamage, iMaximumDamage);
            }

            public override void SpecicalAttack_2()
            {
                Health -= 10;
                iDamage = iMaximumDamage * 3;
            }
        }
        class Holi_Boi : PlayerClassTemp
        {
            public Holi_Boi(string InputName)
            {
                iCharacterHealth = 70;
                iCharacterMaxHealth = 70;
                iMinimumDamage = 11;
                iMaximumDamage = 19;
                iPlayerDodgeValue = 4;
                iPlayerAccuracy = 7;
                iMaxMana = 3;
                iMana = iMaxMana;
            }

            public override void SpecialAttack()
            {
                Health += 20;
                iDamage = Convert.ToInt32((iMinimumDamage + iMaximumDamage) / 2);
            }
            public override void SpecicalAttack_2()
            {
                iDamage = Convert.ToInt32(iCharacterHealth / 3);
            }


        }


    }
}
