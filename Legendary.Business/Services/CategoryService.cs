using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Legendary.Business.Interfaces;
using Legendary.Business.Models;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CategoryService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public void Create(Category category)
        {
            //TODO Проверить роль
            if (category == null
                || CategoryIsInDb(
                    c => string.Equals(c.Name, category.Name, StringComparison.InvariantCultureIgnoreCase),
                    out var categories))
                //TODO Вернуть ошибку о создании
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            category.Id = Guid.NewGuid().ToString();
            _uow.CategoryRepository.Create(_mapper.Map<CategoryDb>(category));
            _uow.Save();
        }

        public void Update(string categoryId, Category category)
        {
            //TODO Проверить роль
            if (categoryId == null
                || category == null
                || !CategoryIsInDb(c => string.Equals(c.Id, categoryId, StringComparison.InvariantCultureIgnoreCase),
                    out var categories))
                //TODO Вернуть ошибку о создании
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            category.Id = categoryId;
            _uow.CategoryRepository.Update(_mapper.Map<CategoryDb>(category));
            _uow.Save();
        }

        public void Delete(string categoryId)
        {
            //TODO Проверить роль
            if (categoryId == null
                || !CategoryIsInDb(c => string.Equals(c.Id, categoryId, StringComparison.InvariantCultureIgnoreCase),
                    out var categories))
                //TODO Вернуть ошибку о создании
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            _uow.CategoryRepository.Delete(categoryId);
            _uow.Save();
        }

        public Category Get(string id)
        {
            if (id == null)
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            var category = _uow.CategoryRepository.Get(id);

            if (category == null)
                //TODO Вернуть ошибку repository
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            return _mapper.Map<CategoryDb, Category>(category);

        }

        public List<Category> GetAll()
        {
            var categories = _uow.CategoryRepository.GetAll();
            if (categories == null || !categories.Any())
                //TODO Вернуть ошибку repository
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            return categories.Select(s => _mapper.Map<CategoryDb, Category>(s)).ToList();
        }

        public Category GetRandom()
        {
            var categories = _uow.CategoryRepository.GetAll();
            if (categories == null || !categories.Any())
                //TODO Вернуть ошибку repository
                throw new NullReferenceException(); //RequestedResourceNotFoundException();

            var categoriesDto = categories.Select(s => _mapper.Map<CategoryDb, Category>(s)).ToArray();
            return categoriesDto[new Random().Next(0, categoriesDto.Length)];
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        ~ CategoryService()
        {
            Dispose();
        }

        private bool CategoryIsInDb(Predicate<CategoryDb> condition, out IEnumerable<CategoryDb> category)
        {
            category = _uow.CategoryRepository.Find(condition);
            return category.Any();
        }
    }
}