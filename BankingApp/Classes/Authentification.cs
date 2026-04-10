using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    public class Authentification
    {
        private string _correctPincode = "1234";
        public int FailedAttempts { get; private set; }
        public int MaxAttempts { get; private set; }

        public Authentification() //конструктор класса
        {
            FailedAttempts = 0;
            MaxAttempts = 3;
        }

        public bool CheckPin(string enteredPin)
        {
            if (IsBlocked())
            {
                return false;
            }

            else
            {
                if (enteredPin == _correctPincode && IsBlocked() == false)
                {
                    FailedAttempts = 0;
                    return true;
                }
                else
                {
                    FailedAttempts++;
                    return false;
                }
            }
        }

        public bool IsBlocked()
        {
            if (FailedAttempts >= MaxAttempts)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetRemainingAttempts()
        {
            return MaxAttempts - FailedAttempts;
        }
    }
}
