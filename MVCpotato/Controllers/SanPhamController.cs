using DataPotato.Models;
using DataPotato.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCpotato.Models;

namespace MVCpotato.Controllers
{
    public class SanPhamController : Controller
    {
        PotatoDbContext _db;
        AllRepository<SanPham> _repo;
        DbSet<SanPham> _dbSet;

        public SanPhamController()
        {
            _db = new PotatoDbContext();
            _dbSet = _db.SanPhams;
            _repo = new AllRepository<SanPham>(_db, _dbSet);
        }
        //GET: 
        public IActionResult Index()
        {
            var data = _repo.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        //    [HttpPost]
        //    public IActionResult Create(SanPham sp, IFormFile imgFile)//IFormFile là một interface trong ASP.NET Core được sử dụng để đại diện cho các file được upload từ client đến server thông qua các form HTML
        //    {
        //        //Xây dựng 1 đường dẫn để lưu ảnh trong thư mục wwwrooot
        //        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imgFile.FileName);
        //        // Kết quả thu được có dạng như sau: wwwroot/img/concho.png
        //        // Thực hiện việc sao chép file được chọn vào thư mục root
        //        var stream = new FileStream(path, FileMode.Create);//Dòng này tạo một đối tượng FileStream để ghi dữ liệu vào file mới tại đường dẫn vừa tạo. FileMode.Create chỉ định rằng nếu file đã tồn tại, nó sẽ bị ghi đè.
        //        //thuc hien sao chep anh vao thu muc root
        //        imgFile.CopyTo(stream);
        //        sp.ImgURL = imgFile.FileName; //gán tên file ảnh cho thuộc tính imgurl
        //        _repo.CreateObj(sp);
        //        return RedirectToAction("Index");
        //    }
        [HttpPost]
        
        public ActionResult Create(SanPham sp, IFormFile imgFile)
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imgFile.FileName);

            var stream = new FileStream(path, FileMode.Create);

            imgFile.CopyTo(stream);
            sp.ImgURL = imgFile.FileName;
            _repo.CreateObj(sp);
            return RedirectToAction("Index");
        }
    }
}
