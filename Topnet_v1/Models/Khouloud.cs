using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Topnet_v1.Models
{
    public class DurationData
    {
        public string numSequence { get; set; }
        public string userName { get; set; }
        public string gouvernerat { get; set; }
        public DateTime date { get; set; }
        public int dureeConnexionParJour { get; set; }
    }
    public class NumberData
    {
        public string numSequence { get; set; }
        public string userName { get; set; }
        public string gouvernerat { get; set; }
        public DateTime date { get; set; }
        public int nbDeconnexionParJour { get; set; }
    }
    public class SessionData
    {
         public string userName { get; set; }
        public string numSequence { get; set; }
        public DateTime dateDebutSession { get; set; }
        public DateTime dateFinSession { get; set; }
    }
    public class MainClass
    {
        public void Test()
        {
            var myDurationData = new List<DurationData>
            {
                new DurationData
                {
                    numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,15),
                    dureeConnexionParJour= 83386
                },
                 new DurationData
                {
                   numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,17),
                    dureeConnexionParJour= 82530
                },
                   new DurationData
                {
                       numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,18),
                    dureeConnexionParJour= 85453
                },
                     new DurationData
                {
                      numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,20),
                    dureeConnexionParJour= 85781
                },
                             new DurationData
                {
                    numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,21),
                    dureeConnexionParJour= 84950
                },
                                     new DurationData
                {
                      numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,26),
                    dureeConnexionParJour= 84044
                },
                                             new DurationData
                {
                       numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,17),
                    dureeConnexionParJour= 85458
                },


            };


            var myNumberData = new List<NumberData>
            {
                new NumberData
                {
                    numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,15),
                    nbDeconnexionParJour= 1
                },
                 new NumberData
                {
                   numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,17),
                    nbDeconnexionParJour= 1
                },
                   new NumberData
                {
                       numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,18),
                    nbDeconnexionParJour= 1
                },
                     new NumberData
                {
                      numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,20),
                    nbDeconnexionParJour= 2
                },
                             new NumberData
                {
                    numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,21),
                    nbDeconnexionParJour= 2
                },
                                     new NumberData
                {
                      numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,26),
                    nbDeconnexionParJour= 1
                },
                                             new NumberData
                {
                       numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    gouvernerat="Tunis",
                    date= new DateTime(2018,02,17),
                    nbDeconnexionParJour= 1
                },


            };



            var mySessionData = new List<SessionData>
            {
                new SessionData
                {
                    numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,14,5,27,35),
                     dateFinSession = new DateTime(2018,2,15,6,49,50)
                },
                 new SessionData
                {
                  numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,15,6,50,27),
                     dateFinSession = new DateTime(2018,2,16,6,0,13)
                },
                   new SessionData
                {
                      numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,16,6,0,47),
                     dateFinSession = new DateTime(2018,2,17,6,7,36)
                },
                     new SessionData
                {
                    numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,17,6,8,11),
                     dateFinSession = new DateTime(2018,2,18,5,3,41)
                },
                       new SessionData
                {
                    numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,18,5,4,18),
                     dateFinSession = new DateTime(2018,2,19,4,48,31)
                },
                 new SessionData
                {
                  numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,19,4,48,38),
                     dateFinSession = new DateTime(2018,2,20,6,0,27)
                },
                   new SessionData
                {
                      numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,20,6,1,0),
                     dateFinSession = new DateTime(2018,2,20,23,9,5)
                },
                     new SessionData
                {
                    numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,20,23,9,5),
                     dateFinSession = new DateTime(2018,2,21,5,50,41)
                },

                   new SessionData
                {
                    numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,21,5,51,17),
                     dateFinSession = new DateTime(2018,2,21,13,31,29)
                },
                 new SessionData
                {
                  numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,21,13,31,36),
                     dateFinSession = new DateTime(2018,2,22,5,27,14)
                },
                   new SessionData
                {
                      numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,23,0,52,21),
                     dateFinSession = new DateTime(2018,2,24,5,45,7)
                },
                     new SessionData
                {
                    numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,24,5,45,42),
                     dateFinSession = new DateTime(2018,2,25,5,52,38)
                },

         new SessionData
                {
                    numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,25,5,53,13),
                     dateFinSession = new DateTime(2018,2,26,6,12,43)
                },
                  new SessionData
                {
                    numSequence = "6a",
                    userName = "0000006@topnet.tn",
                    dateDebutSession= new DateTime(2018,2,26,6,13,19),
                     dateFinSession = new DateTime(2018,2,27,5,34,3)
                },




            };

        }
    }
}