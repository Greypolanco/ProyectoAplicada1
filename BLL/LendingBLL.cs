using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
public class LendingBLL{
    private Contexto _contexto;

    public LendingBLL(Contexto contexto){
        _contexto = contexto;
    }

    public bool Existe(int loanId)
    {
        return _contexto.Lending.Any( o => o.loanId == loanId); 
    }

    public bool Insertar(Lending loan)
    {
        _contexto.Lending.Add(loan);
        return _contexto.SaveChanges() > 0;
    }

    public bool Modificar(Lending loan)
    {
        _contexto.Entry(loan).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(Lending loan)
    {
        if (!Existe(loan.loanId))
            return this.Insertar(loan);
        else
            return this.Modificar(loan);
    }

    public bool Eliminar (Lending loan)
    {
        _contexto.Entry(loan).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public Lending? Buscar(int loanId)
    {
        return _contexto.Lending.Where(o => o.loanId == loanId)
        .AsNoTracking().SingleOrDefault();
    }

    public List<Lending> GetList(Expression<Func<Lending, bool>> criterion)
    {
        return _contexto.Lending.AsNoTracking().Where(criterion).ToList();
    }
}