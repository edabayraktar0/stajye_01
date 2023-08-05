using Microsoft.AspNetCore.Mvc;
using proje_01.Models;

namespace proje_01.Controllers
{
    public class stajyer_2023_controller : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public readonly ApplicationDbContext _dbContext;

        public stajyer_2023_controller(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public IActionResult Register(kisi model)
        {
            if (ModelState.IsValid)
            {
                // ViewModel'den veritabanına kayıt ekleme işlemleri
                // Örneğin:
                var newkisi = new kisi
                {
                    kisi_id = model.kisi_id,
                    kimlik_no = model.kimlik_no,
                    ad_soyad = model.ad_soyad,
                    dogum_tarihi = model.dogum_tarihi,
                    yasadigi_il = model.yasadigi_il,
                    sinif_id = model.sinif_id

                };

                _dbContext.kisis.Add(newkisi);
                _dbContext.SaveChanges();

                // Kayıt başarılı olduğunda başka bir sayfaya yönlendirme veya mesaj gösterme
                return RedirectToAction("RegistrationSuccess");
            }

            // Model geçerli değilse, hata mesajlarını görüntüleme
            return View(model);
        }
    }
}
