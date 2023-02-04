using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
public class PersonBLL{
    private Contexto _contexto;

    public PersonBLL(Contexto contexto){
        _contexto = contexto;
    }

    public bool Existe(int personId)
    {
        return _contexto.Person.Any( o => o.personId == personId); 
    }

    public bool Insertar(Person person)
    {
        _contexto.Person.Add(person);
        return _contexto.SaveChanges() > 0;
    }

    public bool Modificar(Person person)
    {
        _contexto.Entry(person).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(Person person)
    {
        if (!Existe(person.personId))
            return this.Insertar(person);
        else
            return this.Modificar(person);
    }

    public bool Eliminar (Person person)
    {
        _contexto.Entry(person).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public Person? Buscar(int personId)
    {
        return _contexto.Person.Where(o => o.personId == personId)
        .AsNoTracking().SingleOrDefault();
    }

    public List<Person> GetList(Expression<Func<Person, bool>> criterion)
    {
        return _contexto.Person.AsNoTracking().Where(criterion).ToList();
    }
}