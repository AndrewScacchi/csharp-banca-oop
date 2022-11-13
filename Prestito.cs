// class Prestito
public class Prestito
{
    private int ammontarePrestito;

    // Prestito starting from specified Data
    public Prestito( int ammontare, int valoreRata, DateOnly inizio, DateOnly fine, Cliente intestatario)
    {
        ID += 1;
        Ammontare = ammontare;
        ValoreRata = valoreRata;
        Inizio = inizio;
        Fine = fine;
        Intestatario = intestatario;
    }

    //Prestito from TODAY
    public Prestito( int ammontare, int valoreRata, DateOnly fine, Cliente intestatario)
    {
        ID += 1;
        Ammontare = ammontare;
        ValoreRata = valoreRata;
        //data di oggi
        Inizio = new DateOnly();
        Fine = fine;
        Intestatario = intestatario;
    }



    public static int ID = 0; 
    public int Ammontare { get; set; }

    public int ValoreRata { get; set; }

    public DateOnly Inizio { get; set; }

    public DateOnly Fine { get; set; }

    public Cliente Intestatario { get; set; }


    //tostring
    public override string ToString()
    {
        string stringa = "Prestito da " + Ammontare + 
            " concesso con una rata da " + ValoreRata +
            " Euro al mese. All'utente " + Intestatario.Nome +
            " " + Intestatario.Cognome +
            ". Il prestito è iniziato il " + 
            Inizio + " e finirà il " + Fine +
            " Rate mancanti: " + RateMancanti()
            ;
        return stringa;
    }

    public int RateMancanti()
    {
        DateTime oggi = DateOnly.FromDateTime(DateTime.Now).ToDateTime(TimeOnly.Parse("10:00 PM"));
        DateTime fine = this.Fine.ToDateTime(TimeOnly.Parse("10:00 PM"));
        return fine.Subtract(oggi).Days / 30;
    }
}