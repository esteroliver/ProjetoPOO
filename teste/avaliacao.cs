class Avaliacao{
    private int id_midia, id_av, nota;
    private string comentario;

    public int Id_midia{
        get { return id_midia; }
        set { id_midia = value; }
    }
    public int Id_av{
        get { return id_av; }
        set { id_av = value; }
    }
    public int Nota{
        get { return nota; }
        set { if (value >= 0 && value <= 10) nota = value; }
    }
    public string Comentario{
        get { return comentario; }
        set { comentario = value; }
    }
    public override string ToString(){
        return $"{nota} - {comentario}";
    }
}