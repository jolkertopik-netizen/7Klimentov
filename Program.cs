using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7Klimentov
{
    /// <summary>
    /// Класс для расчёта скидок в системе заказов компании «Мебель-Дом».
    /// </summary>
    public class DiscountCalculator
    {
        /// <summary>
        /// Процент скидки для товаров без заказов в прошлом месяце (15%).
        /// </summary>
        public const decimal DiscountPercent = 15m;

        /// <summary>
        /// Рассчитывает цену со скидкой 15%, если по товару
        /// не было заказов в прошлом месяце.
        /// </summary>
        /// <param name="basePrice">Базовая цена товара.</param>
        /// <param name="hasOrdersLastMonth">Были ли заказы в прошлом месяце.</param>
        /// <returns>Цена со скидкой или базовая цена.</returns>
        public decimal GetDiscountedPrice(decimal basePrice, bool hasOrdersLastMonth)
        {
            if (hasOrdersLastMonth)
                return basePrice;

            return basePrice * (1m - DiscountPercent / 100m);
        }

        /// <summary>
        /// Возвращает размер скидки в денежном выражении.
        /// </summary>
        /// <param name="basePrice">Базовая цена товара.</param>
        /// <param name="hasOrdersLastMonth">Были ли заказы в прошлом месяце.</param>
        /// <returns>Сумма скидки (0, если скидки нет).</returns>
        public decimal GetDiscountAmount(decimal basePrice, bool hasOrdersLastMonth)
        {
            return basePrice - GetDiscountedPrice(basePrice, hasOrdersLastMonth);
        }

        /// <summary>
        /// Формирует текстовое описание скидки для вывода в консоль.
        /// </summary>
        /// <param name="basePrice">Базовая цена товара.</param>
        /// <param name="hasOrdersLastMonth">Были ли заказы в прошлом месяце.</param>
        /// <returns>Строка с описанием применённой скидки.</returns>
        public string GetDiscountDescription(decimal basePrice, bool hasOrdersLastMonth)
        {
            if (hasOrdersLastMonth)
                return "Заказы в прошлом месяце были — скидка не применяется.";

            return $"Заказов в прошлом месяце не было — применена скидка {DiscountPercent}%.";
        }
    }

    /// <summary>
    /// Главный класс программы — демонстрация работы расчёта скидок.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в программу. Выводит базовую цену,
        /// цену со скидкой и информацию об авторе.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        static void Main(string[] args)
        {
            var calculator = new DiscountCalculator();

            decimal price = 10000m; // цена мебели, руб.
            decimal discounted = calculator.GetDiscountedPrice(price, false);
            decimal discountAmount = calculator.GetDiscountAmount(price, false);

            Console.WriteLine("=== Компания «Мебель-Дом» ===");
            Console.WriteLine(calculator.GetDiscountDescription(price, false));
            Console.WriteLine($"Базовая цена: {price} руб.");
            Console.WriteLine($"Размер скидки: {discountAmount} руб.");
            Console.WriteLine($"Цена со скидкой: {discounted} руб.");
            Console.WriteLine();
            Console.WriteLine("Автор: Климентов Д.В, группа И-43");

            Console.ReadKey();
        }
    }
}
