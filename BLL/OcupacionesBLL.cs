using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
public class OcupacionesBLL{
    private Contexto _contexto;

    public OcupacionesBLL(Contexto contexto){
        _contexto = contexto;
    }

    public bool Existe(int OcupacionId)
    {
        return _contexto.Ocupaciones.Any( o => o.OcupacionId == OcupacionId); 
    }

    public bool Insertar(Ocupaciones ocupaciones)
    {
        _contexto.Ocupaciones.Add(ocupaciones);
        return _contexto.SaveChanges() > 0;
    }

    public bool Modificar(Ocupaciones ocupaciones)
    {
        _contexto.Entry(ocupaciones).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(Ocupaciones ocupaciones)
    {
        if (!Existe(ocupaciones.OcupacionId))
            return this.Insertar(ocupaciones);
        else
            return this.Modificar(ocupaciones);
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