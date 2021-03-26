using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class CarImageManager : ICarImageService
	{
		ICarImageDal _carImageDal;

		public CarImageManager(ICarImageDal carImageDal)
		{
			_carImageDal = carImageDal;
		}

		//[ValidationAspect(typeof(CarImageValidator))]
		public IResult Add(IFormFile file, CarImage carImage)
		{
			IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
			if (result != null)
			{
				return result;
			}
			carImage.ImagePath = FileHelper.Add(file);
			carImage.CarImageDate = DateTime.Now;
			_carImageDal.Add(carImage);
			return new SuccessResult();
		}

		[ValidationAspect(typeof(CarImageValidator))]
		public IResult Delete(CarImage carImage)
		{
			var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) +
				_carImageDal.Get(c => c.Id == carImage.Id).ImagePath;
			IResult result = BusinessRules.Run(FileHelper.Delete(oldPath));

			if (result != null)
			{
				return result;
			}

			_carImageDal.Delete(carImage);
			return new SuccessResult();
		}

		public IDataResult<CarImage> Get(int id)
		{
			return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
		}

		public IDataResult<List<CarImage>> GetAll()
		{
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
		}

		public IDataResult<List<CarImage>> GetImagesByCarId(int id)
		{
			return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
		}

		[ValidationAspect(typeof(CarImageValidator))]
		public IResult Update(IFormFile file, CarImage carImage)
		{
			//var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\Images")) +
			//	_carImageDal.Get(c => c.Id == carImage.Id).ImagePath;

			carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c => c.Id == carImage.Id).ImagePath, file);
			carImage.CarImageDate = DateTime.Now;
			_carImageDal.Update(carImage);
			return new SuccessResult();
		}

		private IResult CheckIfImageLimitExceeded(int id)
		{
			var carImagecount = _carImageDal.GetAll(c => c.CarId == id).Count;
			if (carImagecount > 5)
			{
				return new ErrorResult();
			}
			return new SuccessResult();
		}

		private List<CarImage> CheckIfCarImageNull(int id)
		{
			string path = @"\Images\Logo.jpg";
			var result = _carImageDal.GetAll(c => c.CarId == id).Any();
			if (!result)
			{
				return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, CarImageDate = DateTime.Now } };
			}
			return _carImageDal.GetAll(c => c.CarId == id);
		}
	}
}