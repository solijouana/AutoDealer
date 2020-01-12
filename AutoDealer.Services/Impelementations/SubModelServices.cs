using System.Collections.Generic;
using System.Linq;
using AutoDealer.Data.Vehicle;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Services.Impelementations
{
    public class SubModelServices : ISubModelServices
    {
        private IRepository<SubModel> _subRepository;

        public SubModelServices(IRepository<SubModel> subRepository)
        {
            _subRepository = subRepository;
        }
        public IEnumerable<SubModel> GetAllSubModels()
        {
            return _subRepository.Get(null).ToList();
        }

        public void CreateSubModel(SubModel subModel)
        {
            _subRepository.Insert(subModel);
            _subRepository.Save();
        }

        public void EditSubModel(SubModel editedModel)
        {
            _subRepository.Update(editedModel);
            _subRepository.Save();
        }

        public void DeleteSubModel(SubModel model)
        {
            _subRepository.Delete(model);
            _subRepository.Save();
        }

        public void DeleteSubModel(int id)
        {
            _subRepository.Delete(id);
            _subRepository.Save();
        }

        public SubModel GetSubModelById(int modelId)
        {
           return _subRepository.GetById(modelId);
        }

        public void Dispose()
        {
            _subRepository?.Dispose();
        }
    }
}
