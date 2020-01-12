using System;
using System.Collections.Generic;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface ISubModelServices:IDisposable
    {
        IEnumerable<SubModel> GetAllSubModels();
        void CreateSubModel(SubModel subModel);
        void EditSubModel(SubModel editedModel);
        void DeleteSubModel(SubModel model);
        void DeleteSubModel(int id);
        SubModel GetSubModelById(int modelId);
      
    }
}
