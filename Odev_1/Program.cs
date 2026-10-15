using System;

class Operations {

	public bool EvenControl(int numberToCheck){

		return numberToCheck % 2 == 0;
	}

} 

class UI {

	static void Main(){

        Operations operation = new Operations();

        string? input;
        do
        {
            Console.WriteLine("Bir sayı girin, tek mi çift mi kontrol edelim. (Sonlandırmak için 'N' yazın) \n");
            input = Console.ReadLine();

            if (int.TryParse(input, out int intInput))
            {
                if (operation.EvenControl(intInput))
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