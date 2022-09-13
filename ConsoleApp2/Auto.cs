namespace Klassenaufgabe
{
    public class Auto
    {
        //readonly, kommt nur vom konstruktor und soll und darf danach nicht mehr veraendert werden.
        readonly float _maxKraftstoffmenge;
        readonly float _verbrauch;

        //(private) klassenvariablen, mit denen gearbeitet wird.
        int _kilometerstand;
        float _kraftstoffmenge;
        bool _fahrbereit;

        /// <summary>
        /// Default Konstruktor. Erstellt ein neues Auto.
        /// </summary>
        public Auto()
        {
        }

        /// <summary>
        /// Erstellt ein neues Auto mit vorgegebenem Tankvolumen (mit vollem Tank) und vorgegebenem Verbrauch
        /// </summary>
        /// <param name="maxKraftstoffmenge">Kraftstoffmenge, welche in das Auto initial getankt werden soll.</param>
        /// <param name="verbrauch">Verbrauch des Autos je 10km</param>
        public Auto(int maxKraftstoffmenge, int verbrauch)
        {
            //neues auto -> 0 km.
            _kilometerstand = 0;
            _maxKraftstoffmenge = maxKraftstoffmenge;

            //annahme: tank voll bei erstellen des autos.
            _kraftstoffmenge = _maxKraftstoffmenge;
            _verbrauch = verbrauch;

            //fahrbereit ist das auto nur, wenn verbrauch und maxKraftstoffmenge auf werte >0 gesetzt sind.
            _fahrbereit = maxKraftstoffmenge > 0 && verbrauch > 0;
        }

        /// <summary>
        /// Fahren. Macht alles was es braucht, damit ein Auto faehrt.
        /// </summary>
        /// <param name="distanz">Distanz, welche gefahren werden soll.</param>
        public void Fahre(int distanz)
        {
            Console.WriteLine($"Das Auto soll {distanz} km fahren.");

            //initiale pruefung. kann das auto ueberhaupt fahren (tank nicht leer etc?)
            if (!_fahrbereit)
            {
                Console.WriteLine("Auto ist nicht fahrbereit!");
                return;
            }

            //lokale variable zum merken, wie viel km der distanz schon gefahren wurden.
            int gefahreneKm = 0;

            //schleife, welche die distanz farhrt. intervall wie vorgegeben
            while (gefahreneKm < distanz)
            {
                //wie viele km sind wir von der distanz schon gefahren?
                gefahreneKm++;

                //gesamt-km stand erhoehen
                _kilometerstand++;

                //alle 10km wird die Kraftstoffmenge um den Verbrauch des Autos reduziert (unt ein paar tests durchgefuehrt)
                if (_kilometerstand % 10 == 0)
                {
                    _kraftstoffmenge -= _verbrauch;

                    //falls mal negative tankvolumen auftreten sollten ...
                    if (_kraftstoffmenge < 0) _kraftstoffmenge = 0;

                    //wenn nur noch 1/6 der maximalen menge sprit im tank ist, soll eine warnung ausgegeben werden
                    if (_kraftstoffmenge <= _maxKraftstoffmenge / 6 && _kraftstoffmenge > 0)
                    {
                        Console.WriteLine($"ACHTUNG! Nicht mehr viel Sprit im Tank! ({_kraftstoffmenge} liter)");
                    }

                    //wenn tank leer, dann nix mehr fahren. 
                    if (_kraftstoffmenge <= 0)
                    {
                        _fahrbereit = false;
                        Console.WriteLine($"Sprit leer nach {gefahreneKm} km.");
                        break;
                    }
                }

                //automatischer statusbericht alle 150km.
                if (_kilometerstand % 150 == 0)
                {
                    ErstelleStatusbericht(automatisch: true);
                }

                //bei mehr als 1500km ist der motor kaputt. Das auto ist dann nicht mehr fahrbereit.
                if (_kilometerstand >= 1500)
                {
                    Console.WriteLine("Motor kaputt.");
                    _fahrbereit = false;
                    break;
                }
            }

            Console.WriteLine($"Das Auto ist {gefahreneKm} km gefahren.");
            Console.WriteLine($"Das Auto hat jetzt einen Kilometerstand von {_kilometerstand} km.");
        }

        /// <summary>
        /// Erstellt einen Statusbericht
        /// </summary>
        public void ErstelleStatusbericht(bool automatisch = false)
        {
            //einfacher statusbericht. kann wohl noch erweitert werden?
            Console.WriteLine($"{(automatisch ? "Automatischer " : "")}Statusbericht: Das Auto hat einen Kilometerstand von {_kilometerstand} km und es sind {_kraftstoffmenge} liter im Tank. Es ist{(_fahrbereit ? "" : " nicht mehr")} fahrbereit.");
        }

        /// <summary>
        /// Tankt das Auto voll. 
        /// </summary>
        public void Tanken()
        {
            Console.WriteLine($"Es werden {_maxKraftstoffmenge - _kraftstoffmenge}l getankt.");

            //der einfachheit halber wird die kraftstoffmenge auf die maximal moegliche menge gesetzt.
            _kraftstoffmenge = _maxKraftstoffmenge;

            Console.WriteLine($"Es sind jetzt wieder {_kraftstoffmenge} liter im Tank.");

            //das auto ist fahrbereit, wenn sprit im tank ist.
            _fahrbereit = _kraftstoffmenge > 0;
        }

        /// <summary>
        /// Tauscht den Motor des Autos. Neuer Motor = Kilometerstand 0.
        /// </summary>
        public void TauscheMotor()
        {
            Console.WriteLine("Neuer Motor wird eingebaut. Der Kilometerstand wird daher zurueckgesetzt.");

            //neuer motor -> das auto ist wieder fahrbereit. der kilometerstand des neuen motors betraegt 0km.
            _fahrbereit = true;
            _kilometerstand = 0;
        }
    }
}