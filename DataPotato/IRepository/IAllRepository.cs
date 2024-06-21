using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPotato.IRepository
{
    internal interface IAllRepository<T> where T : class
    {
        public ICollection<T> GetAll(); //lấy ra tất cả
        public T GetByID(dynamic id); // Type - lấy bởi Id
        public bool CreateObj(T obj);   //Tạo mới và thêm trong db
        public bool UpdateObj(T obj);    //Sửa và lưu lại trong db
        public bool DeleteObj(dynamic id);   //Xóa đối tượng trong db
    }
}
