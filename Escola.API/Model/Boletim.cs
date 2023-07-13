using System;
using System.Collections.Generic;

namespace Escola.API.Model;

public class Boletim
{
    public int Id { get; set; }
    public int AlunoId { get; set; }
    public Aluno Aluno { get; set; }
    public DateTime OrderDate { get; set; }
    public List<NotaMateria> NotaMaterias { get; set; }
}
