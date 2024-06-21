using DataPotato.IRepository;
using DataPotato.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPotato.Repository
{
    public class AllRepository<H> : IAllRepository<H> where H : class
    {
        private readonly PotatoDbContext _db;
        DbSet<H> _dbSet; //CRUD trên dbset vì nó đại diện cho bảng
                         // Khi cần gọi lại và dùng thật thì lại cần chính xác nó là DBSet nào
                         // Lúc đó ta sẽ gán dbset = DBset cần dùng

        //add dependence injection 
        public AllRepository(PotatoDbContext db, DbSet<H> dbset)
        {
            _db = db;
            _dbSet = dbset;
        }
        public bool CreateObj(H obj)
        {
            try
            {
                _dbSet.Add(obj);
                _db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool DeleteObj(dynamic id)
        {
            try
            {
                var deleteObj = _dbSet.Find(id);
                _dbSet.Remove(deleteObj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ICollection<H> GetAll()
        {
            return _dbSet.ToList();
        }

        public H GetByID(dynamic id)
        {
            return _dbSet.Find(id);
        }

        public bool UpdateObj(H obj)
        {
            try
            {
                _dbSet.Update(obj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
