using System;
using System.Threading.Tasks;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface IModelServices : IDisposable
    {
        void CreateModel(Model newModel);
        void EditModel(Model editedModel);
        void DeleteModel(Model model);
        void DeleteModel(int modelId);
        Task<Model> GetModelById(int modelId);
    }
}
