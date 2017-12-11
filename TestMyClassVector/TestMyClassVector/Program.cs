using System;
using KVector.Vector;
using KLogger;

namespace TestMyClassVector
{
    class Program
    {
        static void Main()
        {
            Logger log = new Logger("Main");
            log.Log("Запущенно програму", LoggerLevel.Debug);

            var rand = new Random();
            try
            {
                var firstVektor = new Vector(rand.Next(-1, 20), rand.Next(-8, 6), rand.Next(-12, 47));
                var seconVektor = new Vector(rand.Next(-14, 15), rand.Next(-8, 35), rand.Next(0, 17));
                log.Log("Створено два вектора A i B. " +
                        $"Перший векртор(A): {firstVektor.ToString()}. Довжина={firstVektor.Length};\nДругий векртор(B): {seconVektor.ToString()}. Довжина={seconVektor.Length};"
                    , LoggerLevel.Info);
                Console.WriteLine(
                    $"Перший векртор(A): {firstVektor.ToString()}. Довжина={firstVektor.Length};\nДругий векртор(B): {seconVektor.ToString()}. Довжина={seconVektor.Length};");
                try
                {
                    log.Log("Додаються два вектора A i B", LoggerLevel.Debug);
                    var resultVector = firstVektor + seconVektor;
                    Console.WriteLine($"Сума векторiв(A+B): {resultVector.ToString()};");
                    log.Log($"Сума векторiв(A+B): {resultVector.ToString()};", LoggerLevel.Info);
                }
                catch (Exception)
                {
                    log.Log("Вектори не вдалось додати!", LoggerLevel.Error);
                    throw;
                }

                try
                {
                    log.Log("Віднімається від  вектора A  вектор B", LoggerLevel.Debug);
                    var resultVector = firstVektor - seconVektor;
                    Console.WriteLine($"Рiзниця векторiв(A-B): {resultVector.ToString()};");
                    log.Log($"Рiзниця векторiв(A-B): {resultVector.ToString()};", LoggerLevel.Info);
                }
                catch (Exception)
                {
                    log.Log("Вектори не вдалось відняти!", LoggerLevel.Error);
                    throw;
                }

                try
                {
                    log.Log("Множаться два вектора A i B", LoggerLevel.Debug);
                    var resultVector = firstVektor * seconVektor;
                    Console.WriteLine($"Добуток векторiв(A*B): {resultVector};");
                    log.Log($"Добуток векторiв(A*B): {resultVector};", LoggerLevel.Info);
                }
                catch (Exception)
                {
                    log.Log("Вектори не вдалось помножити!", LoggerLevel.Error);
                    throw;
                }

                try
                {
                    log.Log("Розрахунок скалярного добутку векторiв A i B", LoggerLevel.Debug);
                    var resultVector = firstVektor.CrossProduct(seconVektor);
                    Console.WriteLine($"Скалярний добуток векторiв(AxB): {resultVector};");
                    log.Log($"Скалярний добуток векторiв(AxB):  {resultVector};", LoggerLevel.Info);
                }
                catch (Exception)
                {
                    log.Log("Не вдалось знайти скалярний добуток векторiв!", LoggerLevel.Error);
                    throw;
                }

                var thirdVektor = new Vector(rand.Next(-5, 12), rand.Next(-1, 9), rand.Next(-12, 17));
                log.Log("Створено новий вектор С", LoggerLevel.Debug);


                Console.WriteLine($"Третiй вектор(С): {thirdVektor.ToString()};");

                try
                {
                    log.Log("Розрахунок обуток векторiв A,B і C", LoggerLevel.Debug);
                    var resultVector = firstVektor.CrossProduct(seconVektor);
                    Console.WriteLine($"Змiшаний добуток векторiв(AxBxC): {resultVector};");
                    log.Log($"Змiшаний добуток векторiв(AxBxC): {resultVector};", LoggerLevel.Info);
                }
                catch (Exception)
                {
                    log.Log("Не вдалось знайти змiшаний добуток векторiв!", LoggerLevel.Error);
                    throw;
                }
                try
                {
                    log.Log("Розрахунок кута мiж векторами А i B:", LoggerLevel.Debug);
                    var resultVector = firstVektor.AngleBetweenVectors(seconVektor);
                    Console.WriteLine($"Кут мiж векторами А i B: {resultVector};");
                    log.Log($"Кут мiж векторами А i B:: {resultVector};", LoggerLevel.Info);
                }
                catch (Exception)
                {
                    log.Log("Не вдалось знайти довжину кута мiж векторами А i B!", LoggerLevel.Error);
                    throw;
                }
                Console.WriteLine(
                    $"Порiвняння векторiв (А==B)={firstVektor.Equals(seconVektor)} (А==A)={firstVektor.Equals(firstVektor)}.");
            }
            catch (Exception ex)
            {
                log.Log($"Винекла помилка в роботі програми({ex.Message})", LoggerLevel.Fatal);
            }

            Console.ReadKey();
        }
    }
}