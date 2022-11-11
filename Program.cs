using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PW_Note;
using static System.Net.Mime.MediaTypeNames;

namespace PW_4
{
    internal class Programm
    {
        public static int vertical = 1;
        public static int horizontal = 0;
        public static DateTime selectedDate = DateTime.Now;
        public static int onedownload = 1;

        static void Main()
        {
            Note memo1 = new Note()
            {
                name = "Воскресенье.Отдых",
                data1 = new DateTime(2022, 10, 6).Day,
                text = "Отдыхай, кайфуй, наслаждайся жизнью",
                data2 = new DateTime(2022, 10, 6),
            };
            Note memo2 = new Note()
            {
                name = "Завтра понедельний, снова выходной",
                data1 = new DateTime(2022, 11, 6).Day,
                text = "Отдыхай, кайфуй, наслаждайся жизнью уже второй день подряд",
                data2 = new DateTime(2022, 11, 7),
            };
            Note memo3 = new Note()
            {
                name = "Учебный день, гони на пары",
                data1 = new DateTime(2022, 11, 8).Day,
                text = "Как же я устал, ну сколько можно, а это ведь только первый день",
                data2 = new DateTime(2022, 11, 8),
            };
            Note memo4 = new Note()
            {
                name = "Практические работы",
                data1 = new DateTime(2022, 11, 8).Day,
                text = "Да кому они вообще нужны, посиди у ноута , делай вид что чем то занят",
                data2 = new DateTime(2022, 11, 9),
            };
            Note memo5 = new Note()
            {
                name = "И снова учеба",
                data1 = new DateTime(2022, 11, 8).Day,
                text = "Ну приди хотя бы на одну пару.",
                data2 = new DateTime(2022, 11, 10),
            };
            Note memo6 = new Note()
            {
                name = "Благодарность",
                data1 = new DateTime(2022, 11, 10).Day,
                text = "Поблагодари лучшего преподавателя(Софья Алексьеевна)",
                data2 = new DateTime(2022, 11, 11),
            };

            Note memo7 = new Note();
            Note memo8 = new Note();
            Note memo9 = new Note();
            Note memo10 = new Note();

            if(onedownload == 1)
            {
                Note.schedule.Add(memo1);
                Note.schedule.Add(memo2);
                Note.schedule.Add(memo3);
                Note.schedule.Add(memo4);
                Note.schedule.Add(memo5);
                Note.schedule.Add(memo6);
                Note.schedule.Add(memo7);
                Note.schedule.Add(memo8);
                Note.schedule.Add(memo9);
                Note.schedule.Add(memo10);
            }
            onedownload++;

            Console.WriteLine("  Выберите дейставие с ежедневником:\n  добавить заметку\n  читать заметки");
            ConsoleKeyInfo pointer = Console.ReadKey();

            while (pointer.Key != ConsoleKey.Enter)
            {
                if (pointer.Key == ConsoleKey.DownArrow)
                {
                    vertical++;
                    if (vertical > 2)
                    {
                        vertical--;
                    }
                }
                else if (pointer.Key == ConsoleKey.UpArrow)
                {
                    vertical--;
                    if (vertical < 1)
                    {
                        vertical++;
                    }
                }
                Console.Clear();
                Console.WriteLine("  Выберите дейставие с ежедневником: ");
                Console.WriteLine("  добавить заметку");
                Console.WriteLine("  читать заметки");
                Console.SetCursorPosition(0, vertical);
                Console.WriteLine("->");
                pointer = Console.ReadKey();
            }
            if (vertical == 1)
            {
                Console.Clear();
                WriteMemo();
            }
            else
            {
                Console.Clear();
                ReadMemo();
            }
        }
        static void WriteMemo()
        {
            Console.WriteLine("Создание новой заметки:");
            foreach (Note item in Note.schedule)
            {
                if (item.name == "заметка")
                {
                    item.data1 = new DateTime(2022, 11, 11).Day;
                    Console.WriteLine("введите название новой заметки: ");
                    string writename = Console.ReadLine();
                    item.name = writename;
                    Console.WriteLine("введите текст: ");
                    string writetext = Console.ReadLine();
                    item.text = writetext;
                    item.data2 = DateTime.Now;
                    break;
                }
            }
            Console.Clear();
            Main();
        }
        static void ReadMemo()
        {
            ConsoleKeyInfo pointer = Console.ReadKey();
            while (pointer.Key != ConsoleKey.Escape)
            {
                if (pointer.Key == ConsoleKey.DownArrow)
                {
                    vertical++;
                }
                else if (pointer.Key == ConsoleKey.UpArrow)
                {
                    vertical--;
                }
                else if (pointer.Key == ConsoleKey.RightArrow)
                {
                    horizontal++;
                }
                else if (pointer.Key == ConsoleKey.LeftArrow)
                {
                    horizontal--;
                }

                if (vertical < 1)
                {
                    vertical = 1;
                }
                else if (vertical > 5)
                {
                    vertical = 1;
                }

                Console.Clear();
                Console.SetCursorPosition(2, 0);
                Console.WriteLine($"Выбрана дата: " + selectedDate.AddDays(horizontal).Day + "." + selectedDate.AddDays(vertical).Month);
                Console.SetCursorPosition(0, vertical);
                Console.WriteLine("->");
                Read(pointer, selectedDate);
                pointer = Console.ReadKey();
            }
            Console.Clear();
            Main();
        }
        public static void Read(ConsoleKeyInfo vmove, DateTime selectedDate)
        {
            selectedDate = selectedDate.AddDays(horizontal);

            if (vmove.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                int i = 0;
                foreach (Note item in Note.schedule)
                {
                    if (item.data1 == selectedDate.Day )
                    {
                        i++;
                        if (i == vertical)
                        {
                            Console.Clear();
                            Console.WriteLine(item.name);
                            Console.WriteLine(item.text);
                            Console.Write("Планируемая дата выполнения: ");
                            string date = DateTime.UtcNow.GetDateTimeFormats('d')[0];
                            Console.WriteLine(date);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Memo not found. Try again");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Memo not found. Try again");
                    }
                }
            }
            if (vmove.Key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(2, 1);

                int o = 1;
                foreach (Note item in Note.schedule)
                {
                    if (item.data1 == selectedDate.Day)
                    {
                        Console.SetCursorPosition(2, o);
                        Console.WriteLine(" " + o + "." + item.name);
                        o++;
                    }
                }
            }
        }
    }
}
