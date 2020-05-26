using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
    public class DailyRoute //Pojedyńczy wyjazd. Trasa z punktu A do B. Obiekt reprezentujący nowe wydarzenie w aplikacji. Przykład, kierowca rusza w trasę a do DailyRouta pasażerowie mogą sie podpiąć.
    {
        public Guid Id { get; protected set; }
        public  Route Route { get; protected set; } //Szczegóły dotyczące ścieżki, czyli węzeł początkowy i końcowy.
        public IEnumerable<PassengerNode> PassangerNodes { get; protected set; } // Kolekcja pasażerów czyli gdzie się ma zatrzymać i kogo po drodzę odebrać. Typ reprezentujacy zatrzymanie po pasażera w okreslonym miejscu.
    }
}
