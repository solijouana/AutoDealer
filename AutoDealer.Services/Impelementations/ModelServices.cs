using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDealer.Data.Vehicle;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Services.Impelementations
{
    public class ModelServices : IModelServices
    {
        private IRepository<Model> _modelRepository;
        private IRepository<SubModel> _subModelRepository;

        public ModelServices(IRepository<Model> modelRepository, IRepository<SubModel> subModelRepository)
        {
            _modelRepository = modelRepository;
            _subModelRepository = subModelRepository;
        }

        public IEnumerable<Model> GetAllModels()
        {
            return _modelRepository.Get(null).ToList();
        }

        public void CreateModel(Model newModel)
        {
            _modelRepository.Insert(newModel);
            _modelRepository.Save();
        }

        public void EditModel(Model editedModel)
        {
            _modelRepository.Update(editedModel);
            _modelRepository.Save();
        }

        public void DeleteModel(Model model)
        {
            model.IsDelete = true;
            EditModel(model);
        }

        public void DeleteModel(int modelId)
        {
            var model = GetModelById(modelId);
            if (model != null)
            {
                DeleteModel(model);
            }
        }

        public void DeleteHardModel(Model model)
        {
            _modelRepository.Delete(model);
            _modelRepository.Save();
        }

        public void DeleteHardModel(int id)
        {
            var model = _modelRepository.GetById(id);
            if (model != null)
                DeleteHardModel(model);
        }

        public Model GetModelById(int modelId)
        {
            return _modelRepository.GetById(modelId);

        }

        public IEnumerable<Model> GetListModelByManufacturerId(int id)
        {
            var model = _modelRepository.Get(m => m.ManufacturerId == id).ToList();

            return model;
        }

        public void Dispose()
        {
            _modelRepository?.Dispose();
        }

    }
}
