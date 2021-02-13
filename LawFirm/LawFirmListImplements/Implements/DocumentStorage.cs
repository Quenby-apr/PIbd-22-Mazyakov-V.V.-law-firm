using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawFirmBusinessLogic.BindingModels;
using LawFirmBusinessLogic.Interfaces;
using LawFirmBusinessLogic.ViewModels;
using LawFirmListImplement.Models;

namespace LawFirmListImplement.Implements
{
    public class DocumentStorage : IDocumentStorage
    {
        private readonly DataListSingleton source;
        public DocumentStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<DocumentViewModel> GetFullList()
        {
            List<DocumentViewModel> result = new List<DocumentViewModel>();
            foreach (var document in source.Documents)
            {
                result.Add(CreateModel(document));
            }
            return result;
        }
        public List<DocumentViewModel> GetFilteredList(DocumentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<DocumentViewModel> result = new List<DocumentViewModel>();
            foreach (var document in source.Documents)
            {
                if (document.DocumentName.Contains(model.DocumentName))
                {
                    result.Add(CreateModel(document));
                }
            }
            return result;
        }
        public DocumentViewModel GetElement(DocumentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var document in source.Documents)
            {
                if (document.Id == model.Id || document.DocumentName == model.DocumentName)
                {
                    return CreateModel(document);
                }
            }
            return null;
        }
        public void Insert(DocumentBindingModel model)
        {
            Document tempDocument = new Document { Id = 1, DocumentComponents = new Dictionary<int, int>() };
            foreach (var document in source.Documents)
            {
                if (document.Id >= tempDocument.Id)
                {
                    tempDocument.Id = document.Id + 1;
                }
            }
            source.Documents.Add(CreateModel(model, tempDocument));
        }
        public void Update(DocumentBindingModel model)
        {
            Document tempDocument = null;
            foreach (var document in source.Documents)
            {
                if (document.Id == model.Id)
                {
                    tempDocument = document;
                }
            }
            if (tempDocument == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempDocument);
        }
        public void Delete(DocumentBindingModel model)
        {
            for (int i = 0; i < source.Documents.Count; ++i)
            {
                if (source.Documents[i].Id == model.Id)
                {
                    source.Documents.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Document CreateModel(DocumentBindingModel model, Document document)
        {
            document.DocumentName = model.DocumentName;
            document.Price = model.Price;
            // удаляем убранные 
            foreach (var key in document.DocumentComponents.Keys.ToList())
            {
                if (!model.DocumentComponents.ContainsKey(key))
                {
                    document.DocumentComponents.Remove(key);
                }
            }    // обновляем существуюущие и добавляем новые   
            foreach (var component in model.DocumentComponents)
            {
                if (document.DocumentComponents.ContainsKey(component.Key))
                {
                    document.DocumentComponents[component.Key] = model.DocumentComponents[component.Key].Item2;
                }
                else
                {
                    document.DocumentComponents.Add(component.Key, model.DocumentComponents[component.Key].Item2);
                }
            }
            return document;
        }
        private DocumentViewModel CreateModel(Document document)
        {    // требуется дополнительно получить список компонентов для изделия с названиями и их количество  
            Dictionary<int, (string, int)> documentComponents = new Dictionary<int, (string, int)>();
            foreach (var dc in document.DocumentComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (dc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                documentComponents.Add(dc.Key, (componentName, dc.Value));
            }
            return new DocumentViewModel
            {
                Id = document.Id,
                DocumentName = document.DocumentName,
                Price = document.Price,
                DocumentComponents = documentComponents
            };
        }
    }
}
