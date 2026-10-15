using System;

class NumberChecker
{
    private int _number;

    // Getter / Setter
    public int Number
    {
        get 
        { 
            return _number; 
        }
        set 
        { 
            _number = value; 
        }
    }

    public bool IsEven()
    {
        return _number % 2 == 0;
    }
} 

class UI 
{
    static void Main()
    {
        // Nesnemizi (object) oluşturuyoruz
        NumberChecker checker = new NumberChecker();

        string? input;
        do
        {
            Console.WriteLine("Bir sayı girin, tek mi çift mi kontrol edelim. (Sonlandırmak için 'N' yazın) \n");
            input = Console.ReadLine();

            if (int.TryParse(input, out int intInput))
            {
                // Değeri Setter aracılığıyla nesnemize atıyoruz
                checker.Number = intInput;

                // Nesnemiz kendi içindeki değişkeni kullanarak sonucu döndürüyor
                if (checker.IsEven())
                {
                    Console.WriteLine("Söylediğiniz sayı çift.\n");
                }
                else
                {
                    Console.WriteLine("Söylediğiniz sayı tek.\n");
                }
            }
            else
            {
                if (input is not null && input.ToUpper() != "N")
                {
                    Console.WriteLine("Lütfen sadece bir sayı girin.\n");
                }
            }

        } while (input is not null && input.ToUpper() != "N");
    }
}