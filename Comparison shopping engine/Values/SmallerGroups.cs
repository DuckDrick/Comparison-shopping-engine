using System;
using System.Collections.Generic;
namespace Comparison_shopping_engine
{
    class SmallerGroups
    {
        public Boolean Check(string productgroup, List<string> smallergroup)
        {
            foreach (var group in smallergroup)
            {
                if (productgroup.Equals(group))
                {
                    return true;
                }
            }

            return false;
        }

        public List<string> VaikaiGroup()
        {
            List<String> group = new List<string>();
            group.Add("Žaislai, prekės vaikams");
            group.Add("Gimtadienio atributika");
            group.Add("Kūdikių higienos prekės");
            group.Add("Vaikams ir kūdikiams");
            group.Add("DOVANOS, ŠVENTINĖ ATRIBUTIKA");
            group.Add("VAIKUI IR MAMAI, ŽAISLAI");
            return group;
        }

        public List<string> AprangaGroup()
        {  
            List<String> group = new List<string>();
            group.Add("Apranga, avalynė, aksesuarai");
            return @group;
        }
        public List<String> AutomobilisGroup()
        {
            List<String> group = new List<string>();
            group.Add("Ratų varžtai");
            group.Add("Kėbulo apsaugos, deflektoriai");
            group.Add("Stabilizatoriaus traukės, stabilizatoriai");
            group.Add("Diržai juostiniai");
            group.Add("Pedalų gumos, pedalų laikikliai");
            group.Add("Variklio dangtelio elementai");
            group.Add("Glaistymo ir gruntavimo medžiagos");
            group.Add("Uždegimo žvakės");
            group.Add("Juostinių diržų įtempikliai, įtempimo skriemuliai");
            group.Add("Variklio galvos tarpinės");
            group.Add("Vairaračio užvalkalai ir priedai");
            group.Add("Išorės priežiūros priemonės");
            group.Add("Priemonės nuo uodų ir erkių");
            group.Add("Purvasaugiai, įkrovos nuėmėjai");
            group.Add("Langų,žibintų plovimo varikliukai");
            group.Add("Veidrodžiai");
            group.Add("Variklio įsiurbimo/išmetimo kolektorių tarpikliai");
            group.Add("Variklio skriemuliai, krumpliaračiai");
            group.Add("Stiklų valikliai ir poliroliai");
            group.Add("Kempinės ir servetėlės");
            group.Add("Variklio alyvos siurblys, siurblio priedai");
            group.Add("Paskirstymo diržų montavimo komplektai");
            group.Add("Pusašiai, lankstai");
            group.Add("Pavarų svirties rankenos");
            group.Add("Bagažinės pertvaros ir grotelės");
            group.Add("Laikikliai ir fiksatoriai");
            group.Add("Motociklų ir motorolerių dalys");
            group.Add("Stabilizatoriaus įvorės");
            group.Add("Įvairūs riebokšliai");
            group.Add("Ratlankiai");
            group.Add("Pakabos montavimo elementai, suvedimo varžtai");
            group.Add("Ratų guoliai");
            group.Add("Sankabos išminamieji guoliai");
            group.Add("Pakabos-važiuoklės įvorės");
            group.Add("Buksyravimo kilpos, kabliai");
            group.Add("Kilimėliai");
            group.Add("Autom.transmisijos filtrai");
            group.Add("Pavarų svirties užvalkalai");
            group.Add("Bagažinės kilimėliai");
            group.Add("Diržai trapeciniai");
            group.Add("Automobiliu_prekes");
            group.Add("Kiti automobilių aksesuarai, priedai");
            group.Add("Autoprekės");
            group.Add("AUTOMOBILIŲ PREKĖS");
            return group;
        }
        public List<string> BaldaiGroup()
        {
            List<String> group = new List<string>();
            return group;
        }

        
        public List<string> BuitinėGroup()
        {
            List<String> group = new List<string>();
            group.Add("Buities prekės");
            group.Add("Smulki buitinė technika");
            group.Add("Stambi buitinė technika");
            group.Add("Stalo servetėlės, vienkartinės staltiesės");
            group.Add("Kavavirės, kavamalės");
            group.Add("Vonios kambario stiklinės");
            group.Add("Vienkartinės servetėlės, nosinės, vatos gaminiai");
            group.Add("Dušo užuolaidos");
            group.Add("Kiti stalo serviravimo indai");
            group.Add("Svetainės, miegamojo staliniai šviestuvai");
            group.Add("Vienkartinės taurės, bokalai");
            group.Add("Tekstilinės servetėlės, staltiesės");
            group.Add("Šluostės");
            group.Add("Kavos, arbatos puodeliai");
            group.Add("Pramoniniai popieriaus gaminiai");
            group.Add("Dekoratyviniai buities elementai");
            group.Add("Reprodukcijos, paveikslai, sienų dekoracijos");
            group.Add("Termosai, gertuvės");
            group.Add("Kempinės, šluostės, grandikliai");
            group.Add("Puodeliai su lėkštute");
            group.Add("Pramoniniai laikikliai, dozatoriai");
            group.Add("Konditerijos įrankiai");
            @group.Add("Virtuvės technika");
            group.Add("Virtuvės, buities, apyvokos prekės");
            group.Add("Baldai ir namų interjeras");
            group.Add("Santechnika, remontas, šildymas");
            group.Add("Buitinė technika ir elektronika");
            group.Add("Stambioji buitinė technika");
            group.Add("Montuojamoji buitinė technika");
            group.Add("Periferija, Biuro įranga");
            group.Add("Namų elektronika");
            group.Add("Buitinė technika. Kavos aparatai");
            group.Add("SANTECHNIKA, ŠILDYMAS");
            group.Add("BUITINĖ TECHNIKA IR ELEKTRONIKA");
            group.Add("LEMPOS IR APŠVIETIMAS");
            group.Add("BALDAI IR NAMŲ INTERJERAS");
            group.Add("BUITIES, VIRTUVĖS, APYVOKOS PREKĖS");
            return group;
        }

        public List<string> GarsasGroup()
        {
            List<String> group = new List<string>();
            group.Add("Vaizdo ir garso technika");
            group.Add("Garso ir vaizdo technika");
            return group;
        }
        public List<string> GyvunaiGroup()
        {
            List<String> group = new List<string>();
            group.Add("Gyvūnų prekės");
            group.Add("PREKĖS GYVŪNAMS");
            return group;
        }

        public List<string> GrožisGroup()
        {
            List<String> group = new List<string>();
            group.Add("Sveikata, grožis ir laisvalaikis");
            group.Add("Kvepalai, kosmetika");
            group.Add("Grožis ir sveikata");
            group.Add("KVEPALAI, KOSMETIKA");
            return group;
        }

        public List<string> KameraGroup()
        {
            List<String> group = new List<string>();
            group.Add("Vaizdo ir garso technika");
            group.Add("Mobilieji telefonai, Foto ir Video");
            return group;
        }
        public List<string> KancialiarinėsGroup()
        {
            List<String> group = new List<string>();
            group.Add("Dekupažo, tapybos ant šilko prekės");
            return group;
        }
        public List<string> KnygaGroup()
        {
            List<String> group = new List<string>();
            group.Add("Knygos");
            group.Add("KNYGOS, BIURO PREKĖS");
            return group;
        }

        public List<string> KompiuterisGroup()
        {
            List<String> group = new List<string>();
            group.Add("Kompiuteriai ir jų komponentai");
            group.Add("Vaizdo ir garso technika");
            group.Add("Kompiuteriniai žaidimai");
            group.Add("Nešiojami kompiuteriai");
            group.Add("Kompiuterių krepšiai, kuprinės, dėklai");
            group.Add("Kompiuterių priedai");
            group.Add("Žaidimų kompiuteriai ir žaidimai");
            group.Add("Kiti kompiuterių aksesuarai");
            @group.Add("Kompiuteriai, telefonai, IT");
            group.Add("Kompiuterinė technika");
            group.Add("Televizoriai");
            group.Add("Žaidimų kompiuteriai ir jų priedai");
            group.Add("Kompiuteriai, Komponentai");
            group.Add("Žaidimų įranga, žaidimai");
            group.Add("Telefonai ir planšetiniai kompiuteriai");
            group.Add("KOMPIUTERINĖ TECHNIKA");
            return group;
        }



        public List<string> LaisvalaikisGroup()
        {
            List<String> group = new List<string>();
            group.Add("Laisvalaikio prekės");
            group.Add("Gimtadienio atributika");
            group.Add("Sportas, laisvalaikis, turizmas");
            group.Add("Riedžiai ir paspirtukai");
            group.Add("SPORTAS, LAISVALAIKIS, TURIZMAS");
            return group;
        }

        public List<string> MaistasGroup()
        {
            List<String> group = new List<string>();
            return group;
        }

        public List<string> SodasGroup()
        {
            List<String> group = new List<string>();
            group.Add("Kiti įrankiai");
            group.Add("Apskaitos skydai, skydeliai");
            group.Add("Šlifavimo diskai");
            group.Add("Diskiniai pjūklai");
            group.Add("Elektrinių įrankių dalys, priedai");
            group.Add("Elektriniai atsuktuvai");
            group.Add("Sodo prekės");
            group.Add("Dovanos, šventinė atributika");
            group.Add("Apsaugos, dezinfekcinės priemonės");
            group.Add("SODO PREKĖS, ĮRANKIAI");
            return group;
        }
        public List<string> TelefonasGroup()
        {
            List<String> group = new List<string>();
            group.Add("Mobilūs telefonai");
            group.Add("Mobilieji telefonai, Foto ir Video");
            group.Add("Mobilieji telefonai ir jų aksesuarai");
            group.Add("Komunikacinė ir ryšio įranga");
            group.Add("Telefonai, Išmanieji pagalbininkai");
            group.Add("Telefonai ir planšetiniai kompiuteriai");
            group.Add("MOBILIEJI TELEFONAI, FOTO IR VIDEO");
            return group;
        }
    }

}
//group.Add("None");
