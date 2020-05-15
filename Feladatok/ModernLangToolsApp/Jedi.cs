using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    public class Jedi
    {
        //Attribútum: XML formátumú adatfájlban a tulajdonság attribútumként, "Nev" néven jelenjen meg
        [XmlAttribute("Nev")]
        //Auto implemented property: A jedi nevének lekérdezése és beállítása
        public string Name { get; set; }

        //Privát tagváltozó a midichlorian számhoz
        private int midiChlorianCount;

        //Attribútum: XML formátumú adatfájlban a tulajdonság attribútumként, "MidiChlorianSzam" néven jelenjen meg
        [XmlAttribute("MidiChlorianSzam")]
        //Property: A jedi midichlorianjainak számának lekérdezés és beállítása
        public int MidiChlorianCount
        {
            //privát tagváltozó lekérdezése
            get { return midiChlorianCount; }
            //privát tagváltozó értékének beállítása a feltételnek megfelelően érékkel
            set
            {
                if(value <= 10)
                {
                    throw new ArgumentException("You are not a true jedi!");
                }
                midiChlorianCount = value;
            }
        }
    }
}
