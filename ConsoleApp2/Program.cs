// See https://aka.ms/new-console-template for more information

namespace Klassenaufgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Erstelle erstes Auto");

            //erstes auto, wird mit 50l getankt und hat einen verbrauch von 4l / 10km.
            var erstesAuto = new Auto(50, 4);
            erstesAuto.Fahre(10);
            erstesAuto.Fahre(30);
            erstesAuto.ErstelleStatusbericht();
            erstesAuto.Fahre(50);
            erstesAuto.Tanken();
            erstesAuto.Fahre(100);
            erstesAuto.Fahre(400);
            erstesAuto.ErstelleStatusbericht();
            erstesAuto.Fahre(30);
            erstesAuto.Fahre(600);
            erstesAuto.Tanken();
            erstesAuto.ErstelleStatusbericht();
            erstesAuto.Fahre(300);
            erstesAuto.ErstelleStatusbericht();

            Console.WriteLine("\n\nErstelle zweites Auto");

            //zweites auto. erstellung durch default constructor.
            var zweitesAuto = new Auto();
            zweitesAuto.Fahre(10);
            zweitesAuto.Fahre(30);
            zweitesAuto.ErstelleStatusbericht();
            zweitesAuto.Fahre(50);
            zweitesAuto.Tanken();
            zweitesAuto.Fahre(100);
            zweitesAuto.Fahre(400);
            zweitesAuto.ErstelleStatusbericht();
            zweitesAuto.Fahre(30);
            zweitesAuto.Fahre(600);
            zweitesAuto.Tanken();
            zweitesAuto.ErstelleStatusbericht();
            zweitesAuto.Fahre(300);
            zweitesAuto.ErstelleStatusbericht();
        }
    }
}