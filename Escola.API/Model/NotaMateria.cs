namespace Escola.API.Model;

public class NotaMateria
{
    public int Id { get; set; }
    public float Nota { get; set; }
    public int BoletimId { get; set; }
    public int MateriaId { get; set; }
    public Boletim Boletim { get; set; }
    public Materia Materia { get; set; }
}
