using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ISliderService
	{
        List<Slider> GetAll();
        List<Slider> GetListStatusTrue();
        List<Slider> GetSliderByID(int id);
        Slider GetByID(int id);
        void SliderAdd(Slider slider);
        void SliderUpdate(Slider slider);
        void SliderDelete(Slider slider);
    }
}
