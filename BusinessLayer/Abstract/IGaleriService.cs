using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IGaleriService
	{
        List<Galeri> GetAll();
        List<Galeri> GetListStatusTrue();
        List<Galeri> GetGaleriByID(int id);
        Galeri GetByID(int id);
        void GaleriAdd(Galeri galeri);
        void GaleriUpdate(Galeri galeri);
        void GaleriDelete(Galeri galeri);
    }
}
