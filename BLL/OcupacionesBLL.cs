using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
public class OcupacionesBLL{
    private Contexto _contexto;

    public OcupacionesBLL(Contexto contexto){
        _contexto = contexto;
    }

    public bool Exist(int OcupacionId)
    {
        return _contexto.Ocupaciones.Any( o => o.OcupacionId == OcupacionId); // No entendi bien
    }

    public bool Insert(Ocupaciones ocupaciones)
    {
        _contexto.Ocupaciones.Add(ocupaciones);
        return _contexto.SaveChanges() > 0;
    }

    public bool Modify(Ocupaciones ocupaciones)
    {
        _contexto.Entry(ocupaciones).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Save(Ocupaciones ocupaciones)
    {
        if (!Exist(ocupaciones.OcupacionId))
            return this.Insert(ocupaciones);
        else
            return this.Modify(ocupaciones);
    }

    public bool Eliminar (Ocupaciones ocupaciones)
    {
        _contexto.Entry(ocupaciones).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public Ocupaciones? Buscar(int OcupacionId)
    {
        return _contexto.Ocupaciones.Where(o => o.OcupacionId == OcupacionId)
        .AsNoTracking().SingleOrDefault();
    }

    public List<Ocupaciones> GetList(Expression<Func<Ocupaciones, bool>> criterion)
    {
        return _contexto.Ocupaciones.AsNoTracking().Where(criterion).ToList();
    }
}