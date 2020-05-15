using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    class Program
    {
        [Description("Feladat2")]
        static void serializeTest()
        {
            Console.WriteLine("2. Feladat: ");

            Jedi j = new Jedi();
            j.Name = "Anakin Skywalker";
            j.MidiChlorianCount = 20000;

            //'j' Jedi objektum kiíratása XML forátumú adatfájlba
            FileStream stream = null;
            try
            {
                stream = new FileStream("jedi.txt", FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
                serializer.Serialize(stream, j);
            }
            catch (Exception e)
            {
                Console.WriteLine("Az objektum kiíratása nem sikerült!");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(stream != null)
                {
                    stream.Close();
                }
            }

            //Az XML forátumú adatfájl beolvasása
            stream = null;
            try
            {
                stream = new FileStream("jedi.txt", FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
                Jedi clone = (Jedi)serializer.Deserialize(stream);
                Console.WriteLine("Nev: {0}\tMidiChlorian szam: {1}", clone.Name, clone.MidiChlorianCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Az fájl beolvasása nem sikerült!");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        static void initJediCouncil(JediCouncil council)
        {
            Jedi anakin = new Jedi();
            anakin.Name = "Anakin Skywalker";
            anakin.MidiChlorianCount = 20000;

            Jedi obiwan = new Jedi();
            obiwan.Name = "Obi-Wan Kenobi";
            obiwan.MidiChlorianCount = 10000;

            Jedi mace = new Jedi();
            mace.Name = "Mace Windu";
            mace.MidiChlorianCount = 299;

            Jedi plo = new Jedi();
            plo.Name = "plo koon";
            plo.MidiChlorianCount = 100;

            council.Add(anakin);
            council.Add(obiwan);
            council.Add(mace);
            council.Add(plo);
        }

        //CouncilChangingDelegate-nek megfelelő felépítésű metódus
        //Az üzenetek consolra íratásához
        static void MessageReceived(string msg)
        {
            Console.WriteLine(msg);
        }

        [Description("Feladat3")]
        static void jediCouncilTest()
        {
            Console.WriteLine("\n3. Feladat: ");

            JediCouncil council = new JediCouncil();
            //A MessageReceived metódus beregisztrálása a CouncilChanging eseményre
            council.CouncilChanging += MessageReceived;

            initJediCouncil(council);

            council.Remove();
            council.Remove();
            council.Remove();
            council.Remove();

            //A MessageReceived metódus leiratkoztatása a CouncilChanging eseményre
            council.CouncilChanging -= MessageReceived;
        }

        [Description("Feladat4")]
        static void beginnersTest()
        {
            Console.WriteLine("\n4. Feladat: ");

            JediCouncil council = new JediCouncil();

            initJediCouncil(council);

            //A kezdő Jedik lekérése és kilistázása
            List<Jedi> beginners = council.GetBeginners();
            foreach (Jedi j in beginners)
            {
                Console.WriteLine("Nev: {0}\tMidiChlorian szam: {1}", j.Name, j.MidiChlorianCount);
            }
        }

        static void Main(string[] args)
        {
            serializeTest();
            jediCouncilTest();
            beginnersTest();

            Console.ReadKey();
        }
    }
}
