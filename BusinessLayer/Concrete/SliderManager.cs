using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class SliderManager:ISliderService
	{
		ISliderDal _sliderDal;

		public SliderManager(ISliderDal sliderDal)
		{
			_sliderDal = sliderDal;
		}

		public List<Slider> GetAll()
		{
			return _sliderDal.GetAll();
		}

		public Slider GetByID(int id)
		{
			return _sliderDal.Get(x => x.SliderId == id);
		}

		public List<Slider> GetListStatusTrue()
		{
			return _sliderDal.GetAll(x=>x.Status==true).OrderByDescending(z=>z.SliderAddDate).ToList();
		}

		public List<Slider> GetSliderByID(int id)
		{
			return _sliderDal.GetAll(x => x.SliderId == id);
		}

		public void SliderAdd(Slider slider)
		{
			_sliderDal.Add(slider);
		}

		public void SliderDelete(Slider slider)
		{
			_sliderDal.Delete(slider);
		}

		public void SliderUpdate(Slider slider)
		{
			_sliderDal.Update(slider);
		}
	}
}
