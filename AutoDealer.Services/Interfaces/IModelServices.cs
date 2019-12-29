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
        Model GetModelById(int modelId);
    }
}
