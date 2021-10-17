using AutoMapper;
using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.MVC.ViewModel;

namespace LCesarAdvogados.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public virtual string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
           CreateMap<UsuarioViewModel, Usuario>();
           CreateMap<LoginViewModel, Usuario>();
           CreateMap<PostViewModel, Posts>();
        }
    }
}