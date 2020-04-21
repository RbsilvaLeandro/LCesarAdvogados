using System;
using System.Collections.Generic;
using LCesarAdvogados.Aplicacao.Interface;
using LCesarAdvogados.Dominio.Interfaces.Servicos;

namespace LCesarAdvogados.Aplicacao
{
    public class AppServicoBase<TEntity> : IDisposable, IAppServicoBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> _ServicoBase;
        public AppServicoBase(IServicoBase<TEntity> ServicoBase)
        {
            _ServicoBase = ServicoBase;
        }
        public void Add(TEntity obj)
        {
            _ServicoBase.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _ServicoBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _ServicoBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _ServicoBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _ServicoBase.Remove(obj);
        }

        public void Dispose()
        {
            _ServicoBase.Dispose();
        }
    }
}
