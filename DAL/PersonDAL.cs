using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbank.Model;

namespace Nettbank.DAL
{
    public class PersonDAL
    {
        //Registrerer ny person og legger det i databasen med passord
        public bool regNyPerson(Person innKunde, byte[] passordHash)
        {
            var nyKunde = new Personer()
            {
                Persnr = innKunde.personnummer,
                Fornavn = innKunde.fornavn,
                Etternavn = innKunde.etternavn,
                Adresse = innKunde.adresse,
                Postnr = innKunde.postNr,
                Telefonnr = innKunde.telefonnr,
                Passord = passordHash
            };

            var db = new PersonContext();
            try
            {
                Poststeder poststedFinnes = db.Poststeder.Find(innKunde.postNr);
                if (poststedFinnes == null)
                {
                    var nyttPoststed = new Poststeder()
                    {
                        Postnr = innKunde.postNr,
                        Poststed = innKunde.poststed
                    };
                    nyKunde.Poststeder = nyttPoststed;
                }
                db.Kunder.Add(nyKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        //Finner en person i databasen som matcher personnummer og passord
        public bool finnEnPerson(string personnummer, byte[] passordDB)
        {
            Debug.WriteLine("finnEnKunde 1");
            var db = new PersonContext();
            try
            {
                Personer kunde = db.Kunder.FirstOrDefault(b => b.Passord == passordDB && b.Persnr == personnummer);
                Debug.WriteLine(kunde.Persnr);
                if (kunde != null)
                {
                    Debug.WriteLine("finnEnKunde 3");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        //Lister alle kontoer som en spesifikk person har
        public List<Konto> listAlleKontoer()
        {
            var db = new PersonContext();
            List<Konto> alleKonto = db.Kontoer.Select(k => new Konto()
            {
                kontoNummer = k.Kontonr,
                datoOppretning = k.DatoOppretting,
                saldo = k.Saldo
            }).ToList();
            return alleKonto;
        }

        //?????????????????????????????????
        public static List<Konto> kontoListeKunde(string personnummer)
        {
            var db = new PersonContext();

            List<Konto> kontoListe = db.Kontoer.Select(k => new Konto()
            {
                persnr = k.Persnr,
                kontoNummer = k.Kontonr,
                datoOppretning = k.DatoOppretting,
                saldo = k.Saldo
            }).Where(k => k.persnr == personnummer).ToList();

            return kontoListe;
        }

        //Returnerer et soesifikk kontonummer ????????????????
        public List<Konto> kontonummer()
        {
            var db = new PersonContext();
            var kontNr = db.Kontoer.Select(k => new Konto()
            {
                kontoNummer = k.Kontonr
            }).ToList();
            return kontNr;
        }

        //Finner en kontonummer og returnerer info om den
        public Konto hentEnKonto(long kontonr)
        {
            var db = new PersonContext();

            var enKonto = db.Kontoer.Find(kontonr);

            if (enKonto == null)
            {
                return null;
            }
            else
            {
                var visKonto = new Konto()
                {
                    kontoNummer = enKonto.Kontonr,
                    datoOppretning = enKonto.DatoOppretting,
                    saldo = enKonto.Saldo
                };
                return visKonto;
            }
        }

        //Lister ut transaksjonene som ikke er bekreftet
        public List<Transaksjon> ubekreftetBetalinger()
        {
            var db = new PersonContext();

            List<Transaksjon> ubekreftetTran = db.Transaksjoner.Select(t => new Transaksjon()
            {
                id = t.ID,
                beløp = t.Beløp,
                dato = t.Dato,
                fraKonto = t.FraKonto,
                tilKonto = t.TilKonto,
                kid = t.Kid,
                bekreftet = t.Bekreftet,
            }).Where(t => t.bekreftet == false).ToList();
            return ubekreftetTran;
        }

        //Lister ut transaksjonene som er bekreftet
        public List<Transaksjon> kontoHistorikk()
        {
            var db = new PersonContext();

            List<Transaksjon> bekreftetTran = db.Transaksjoner.Select(t => new Transaksjon()
            {
                id = t.ID,
                beløp = t.Beløp,
                dato = t.Dato,
                fraKonto = t.FraKonto,
                tilKonto = t.TilKonto,
                kid = t.Kid,
                bekreftet = t.Bekreftet,
            }).Where(t => t.bekreftet == true).ToList();
            return bekreftetTran;
        }

        //Registrer en ny transaksjon
        public bool regBetaling(Transaksjon regTran)
        {
            var nyTran = new Transaskjoner()
            {
                FraKonto = regTran.fraKonto,
                TilKonto = regTran.tilKonto,
                Beløp = regTran.beløp,
                Kid = regTran.kid,
                Dato = regTran.dato
            };

            var db = new PersonContext();
            try
            {
                db.Transaksjoner.Add(nyTran);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        //Kunde kan endre på en registrert transaksjon som ikke er bekreftet
        public bool endreBetaling(int id, Transaksjon regTran)
        {
            var db = new PersonContext();
            try
            {
                Transaskjoner endreTran = db.Transaksjoner.Find(id);
                endreTran.Beløp = regTran.beløp;
                endreTran.Dato = regTran.dato;
                endreTran.FraKonto = regTran.fraKonto;
                endreTran.TilKonto = regTran.tilKonto;
                endreTran.Kid = regTran.kid;
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        //Forandrer en transaksjon til bekreftet
        public bool bekrefteBetaling(int id)
        {
            var db = new PersonContext();
            try
            {
                Transaskjoner endreTran = db.Transaksjoner.Find(id);
                endreTran.Bekreftet = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        //Sletter en ubekreftet transaksjon
        public bool slettBetaling(int id)
        {
            var db = new PersonContext();
            try
            {
                Transaskjoner slettTran = db.Transaksjoner.Find(id);
                db.Transaksjoner.Remove(slettTran);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        //Henter en spesifikk transaksjon
        public Transaksjon hentEnTransaksjon(int id)
        {
            var db = new PersonContext();

            var enTran = db.Transaksjoner.Find(id);

            if (enTran == null)
            {
                return null;
            }
            else
            {
                var visTran = new Transaksjon()
                {
                    id = enTran.ID,
                    beløp = enTran.Beløp,
                    dato = enTran.Dato,
                    fraKonto = enTran.FraKonto,
                    tilKonto = enTran.TilKonto,
                    kid = enTran.Kid
                };
                return visTran;
            }
        }
    }
}
