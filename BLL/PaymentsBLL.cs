using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class PaymentsBLL
{
    private Contexto _context;

    public PaymentsBLL(Contexto _context)
    {
        this._context = _context;
    }

    public bool Exist(int paymentID){
       return _context.Payment.Any(Option => Option.PaymentId == paymentID);
    }

    public bool Insert(Payments payment){
        _context.Payment.Add(payment);
        return _context.SaveChanges() >0;
    }

    public bool Modify(Payments payment)
    {
        _context.Database.ExecuteSqlRaw($"Delete from PaymentsDetalle where PaymentId={payment.PaymentId}");
        foreach(var New in payment.PaymentsDetalle)
        {
            _context.Entry(New).State = EntityState.Added;
        }
        _context.Entry(payment).State = EntityState.Modified;
        return _context.SaveChanges() >0;
    }

    public bool Delete(Payments payment){
        _context.Entry(payment).State = EntityState.Deleted;
        return _context.SaveChanges() >0;
    }

    public bool Save(Payments payment){
        if(!Exist(payment.PaymentId))
            return this.Insert(payment);
        else
            return this.Modify(payment);
    }

    public Payments? Search(int paymentID){
       return _context.Payment.Include(payment => payment.PaymentsDetalle).Where(Option => Option.PaymentId == paymentID).AsNoTracking().SingleOrDefault();
    }

    public List<Payments> GetList(Expression<Func<Payments, bool>> criterio){
        return _context.Payment.Include(payment => payment.PaymentsDetalle).AsNoTracking().Where(criterio).ToList();
    }
}