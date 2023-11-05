using System.Text;

namespace G19_20231101
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Type your file location here");

            string filePath = Console.ReadLine(); //@"D:\G19.txt";
            string text = ReadFromFile(filePath);
            Console.WriteLine();

            string newFilePath = @"D:\newG19.txt";
            string[] stringSeparators = new string[] { "\r\n" };

            Console.ForegroundColor = ConsoleColor.Yellow;

            string[] lines = text.Split(stringSeparators, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = $"{i + 1}.{lines[i]}";
                Console.WriteLine(lines[i]);
            }

            Console.ResetColor();
            WriteToFile(newFilePath, string.Join(Environment.NewLine, lines)); // amaze davserche 🙂.
        }

        //string text = "Hello\r\nWorld";
        //WriteToFile(filePath, text);
        /* ამოცანა:
        დამიწერეთ პროგრამა, რომელიც გაშვებისას შეგეკითხებათ ფაილის მისამართს რომლისგანაც წაიკითხავს ტექსტს.
        ამის მერე პროგრამამ უნდა გახსნას ახალი ფაილი (მიუთითეთ რაიმე სახელი ხელით კოდშივე) და გადაიტანოს 
        წასაკითხი ფაილიდან მთელი ინფორმაცია დააკოპიროს ერთიდან მეორეშე, ოღონდ ყოველი სტრიქონი გადანომროს.
        მაგალითად:
        თუ ფაილში წერია შემდეგი ტექსტი
        __________________
        Gio
        Mari
        Dato
        Nika
        __________________
        ახალ ფაილში უნდა გადაიტანოს შემდეგი სახით
        __________________
        1.Gio
        2.Mari
        3.Dato
        4.Nika
        __________________
        */

        static void WriteToFile(string filePath, string text)
        {
            FileStream file = new FileStream(filePath, FileMode.Create);
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            file.Write(buffer, 0, buffer.Length);
            file.Close();
        }

        static string ReadFromFile(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open);
            byte[] buffer = new byte[file.Length];
            file.Read(buffer, 0, buffer.Length);
            file.Close();
            return Encoding.ASCII.GetString(buffer);
        }
    }
}


