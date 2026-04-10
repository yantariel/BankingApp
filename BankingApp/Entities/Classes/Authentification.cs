using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading; //библиотека с таймером

namespace BankingApp.Etities.Classes
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
            _blokedUntil = DateTime.MinValue; //минимально возможная дата (время)
        }

        public bool TryCheckPin(string enteredPin, out string errorText) 
        {
            errorText = string.Empty;

            if (IsBlocked())
            {
                int secondsLeft = GetRemainingBlockSeconds();
                errorText = $"Число попыток ввода пин-кода превышено! Подождите {secondsLeft} сек. до разблокировки.";
                return false;
            }

            if (enteredPin == _correctPincode)
            {
                FailedAttempts = 0;
                return true;
            }
            else
            {
                FailedAttempts++;

                errorText = $"Неверный pin-код!\nОставшееся число попыток: {GetRemainingAttempts()}.";
                return false;
            }
        }

        //public bool TryCheckPin(string enteredPin) 
        //{
        //    if (IsBlocked())
        //    {
        //        int secondsLeft = GetRemainingBlockSeconds();
        //        throw new Exception($"Число попыток ввода пин-кода превышено!  Подождите {secondsLeft} сек. до разблокировки.");
        //    }

        //    if (enteredPin == _correctPincode)
        //    {
        //        FailedAttempts = 0;
        //        return true;
        //    }
        //    else
        //    {
        //        FailedAttempts++;
        //        throw new Exception($"Неверный pin-код!\nОставшееся число попыток: {GetRemainingAttempts()}.");
        //    }
        //}

        public bool CheckPin(string enteredPin) //проверяет введенный пароль на соответствие верному
        {
            if (IsBlocked())
            {
                return false;
            }

            else
            {
                if (enteredPin == _correctPincode)
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

        public bool IsBlocked() //проверяет не заблокирован ли пользователь за превышенное число попыток входа
        {
            if (_blokedUntil > DateTime.Now)  //проверяем заблочен ли пользователь
            {
                return true;
            }

            if (_blokedUntil != DateTime.MinValue && _blokedUntil <= DateTime.Now) //если время блокировки прошло то сбрасываем
            {
                _blokedUntil = DateTime.MinValue;
                FailedAttempts = 0;

                if (_unblockTimer != null)
                {
                    _unblockTimer.Stop();
                    _unblockTimer = null;
                }
            }

            if (FailedAttempts >= MaxAttempts)
            {
                BlockFor90Seconds();
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetRemainingAttempts() //возвращает оставшееся число попыток для вывода пользователю
        {
            return MaxAttempts - FailedAttempts;
        }



        private void BlockFor90Seconds()
        {
            _blokedUntil = DateTime.Now.AddSeconds(90); //берет время компьютера и добавляет к нему 90 секунд

            _unblockTimer = new DispatcherTimer(); //создаем объект таймер
            _unblockTimer.Tick += new EventHandler(OnTick); //связываем функцию которая будет выполняться по таймеру
            _unblockTimer.Interval = TimeSpan.FromSeconds(1); //устанавливаем интервал таймера (каждую секунду)
            _unblockTimer.Start(); //запускаем таймер
        }


        DispatcherTimer _unblockTimer; //инициализируем объект таймер
        private DateTime _blokedUntil; //до какого времени заблокирован; DateTime - структура для хранения времени и даты
        //public event EventHandler<int> BlockTimeChanged; //событие для обновления окошка

        private void OnTick(object sender, EventArgs e) //метод который вызывается по тику таймера
        {
            int secondsLeft = GetRemainingBlockSeconds(); //вычисляем сколько секунд осталось

            //BlockTimeChanged?.Invoke(this, secondsLeft); //вызываем событие для обновления окошка

            if (secondsLeft <= 0) //проверяем не закончислось ли время
            {
                _unblockTimer.Stop(); //выключаем таймер
                _unblockTimer = null; //обнуляем таймер 
                _blokedUntil = DateTime.MinValue;  //минимально возможная дата (время)
                FailedAttempts = 0; //сбрасываем попытки ввода пароля

            }
        }

        public int GetRemainingBlockSeconds() //вовзаращает оставшееся число секунд блокировки
        {
            if (!IsBlocked()) //если пользователь не заблокирован 
            {
                return 0;
            }

            TimeSpan remainingSeconds = _blokedUntil - DateTime.Now; //TimeSpan дает разницу между временем 
            if (remainingSeconds.TotalSeconds < 0) 
            {
                return 0;
            }

            return (int)remainingSeconds.TotalSeconds; //int явное приведение, TotalSeconds возвращает double
        }
    }
}
