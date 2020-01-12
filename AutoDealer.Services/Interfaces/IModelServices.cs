using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface IModelServices : IDisposable
    {
        IEnumerable<Model> GetAllModels();
        void CreateModel(Model newModel);
        void EditModel(Model editedModel);
        void DeleteModel(Model model);
        void DeleteModel(int modelId);
        void DeleteHardModel(Model model);
        void DeleteHardModel(int id);
        Model GetModelById(int modelId);
        IEnumerable<Model> GetListModelByManufacturerId(int id);
        IEnumerable<SubModel> GetSubModelsListByModelId(int modelId);

    }
}
        