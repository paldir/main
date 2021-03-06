﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI
{
    /// <summary>
    /// Przechowuje dane, z których losowane są odpowiednie pola w SampleDataConfig.
    /// </summary>
    static class SampleDataSource
    {
        #region maleNames
        /// <summary>
        /// Tablica napisów zawierająca imiona męskie.
        /// </summary>
        public static string[] maleNames = new string[] 
        { 
            "Jakub",
            "Jan",
            "Mateusz",
            "Bartosz",
            "Kacper",
            "Michał",
            "Szymon",
            "Antoni",
            "Filip",
            "Piotr",
            "Maciej",
            "Aleksander",
            "Franciszek",
            "Mikołaj",
            "Adam",
            "Stanisław",
            "Wiktor",
            "Krzysztof",
            "Wojciech",
            "Igor",
            "Maksymilian",
            "Karol",
            "Dawid",
            "Tomasz",
            "Patryk",
            "Oskar",
            "Paweł",
            "Dominik",
            "Kamil",
            "Oliwier",
            "Ignacy",
            "Marcel",
            "Hubert",
            "Adrian",
            "Sebastian",
            "Łukasz",
            "Julian",
            "Tymon",
            "Krystian",
            "Marcin",
            "Leon",
            "Damian",
            "Miłosz",
            "Alan",
            "Tymoteusz",
            "Kajetan",
            "Grzegorz",
            "Daniel",
            "Rafał",
            "Eryk"
        };
        #endregion

        #region femaleNames
        /// <summary>
        /// Tablica napisów przechowująca imiona żeńskie.
        /// </summary>
        public static string[] femaleNames = new string[]
        {
            "Julia",
            "Maja",
            "Zuzanna",
            "Aleksandra",
            "Natalia",
            "Wiktoria",
            "Zofia",
            "Oliwia",
            "Maria",
            "Alicja",
            "Lena",
            "Amelia",
            "Hanna",
            "Gabriela",
            "Karolina",
            "Anna",
            "Weronika",
            "Antonina",
            "Magdalena",
            "Pola",
            "Martyna",
            "Emilia",
            "Barbara",
            "Patrycja",
            "Małgorzata",
            "Nikola",
            "Marta",
            "Nina",
            "Katarzyna",
            "Dominika",
            "Helena",
            "Joanna",
            "Laura",
            "Agata",
            "Kinga",
            "Paulina",
            "Klaudia",
            "Michalina",
            "Iga",
            "Milena",
            "Jagoda",
            "Matylda",
            "Liliana",
            "Nadia",
            "Łucja",
            "Daria",
            "Izabela",
            "Ewa",
            "Kamila",
            "Blanka"
        };
        #endregion

        #region lastNames
        /// <summary>
        /// Tablica napisów zawierająca nazwiska.
        /// </summary>
        public static string[] lastNames = new string[]
        {
            "Kowalski",
            "Wiśniewski",
            "Dąbrowski",
            "Lewandowski",
            "Wójcik",
            "Kamiński",
            "Kowalczyk",
            "Zieliński",
            "Szymański",
            "Woźniak",
            "Kozłowski",
            "Jankowski",
            "Wojciechowski",
            "Kwiatkowski",
            "Kaczmarek",
            "Mazur",
            "Krawczyk",
            "Piotrowski",
            "Grabowski",
            "Nowakowski",
            "Pawłowski",
            "Michalski",
            "Nowicki",
            "Adamczyk",
            "Dudek",
            "Zając",
            "Król",
            "Jabłoński",
            "Wieczorek",
            "Majewski",
            "Olszewski",
            "Jaworski",
            "Wróbel",
            "Malinowski",
            "Pawlak",
            "Witkowski",
            "Walczak",
            "Stępień",
            "Górski",
            "Rutkowski",
            "Michalak",
            "Sikora",
            "Ostrowski",
            "Baran",
            "Duda",
            "Szewczyk",
            "Tomaszewski",
            "Pietrzak",
            "Marciniak",
            "Wróblewski",
            "Zalewski",
            "Jakubowski",
            "Jasiński",
            "Zawadzki",
            "Sądowski",
            "Bąk",
            "Chmielewski",
            "Włodarczyk",
            "Borkowski",
            "Czarnecki",
            "Sawicki"
        };
        #endregion

        #region postalCodes
        /// <summary>
        /// Tablica napisów przechowująca kody pocztowe.
        /// </summary>
        public static string[] postalCodes = new string[]
        {
            "87100"
        };
        #endregion

        #region cities
        /// <summary>
        /// Tablica napisów przechowująca nazwy miast. Miast powinno być tyle samo, ile kodów pocztowych.
        /// Powinny być umieszczone w miejscach odpowiadających ich kodowi pocztowemu.
        /// </summary>
        public static string[] cities = new string[]
        {
            "Toruń"
        };
        #endregion

        #region streets
        /// <summary>
        /// Tablica napisów przechowująca nazwy ulic.
        /// </summary>
        public static string[] streets = new string[]
        {
            "Polna",
            "Leśna",
            "Słoneczna",
            "Krótka",
            "Szkolna",
            "Ogrodowa", 
            "Lipowa",
            "Brzozowa",
            "Łąkowa",
            "Kwiatowa"
        };
        #endregion
    }
}