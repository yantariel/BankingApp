using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Etities.Classes
{
    internal interface Human
    {
        void Say();
    }

    internal interface Footballer : Human
    {
        void Kick();
    }

    internal interface Programmer : Human
    {
        void Code();
    }

    internal interface Nikita : Footballer, Programmer { }

    class NikitaKozlov : Nikita
    {
        public void Code()
        {
            throw new NotImplementedException();
        }

        public void Kick()
        {
            throw new NotImplementedException();
        }

        public void Say()
        {
            throw new NotImplementedException();
        }
    }

    class Humanity {
        private List<Human> people;

        void PlayFootball()
        {
            foreach (Human human in people)
            {
                if (human is Footballer footballer)
                {
                    footballer.Kick();
                }
            }
        }
    }
}
