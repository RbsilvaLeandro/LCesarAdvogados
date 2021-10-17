using AutoMapper;
using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.MVC.ViewModel;

namespace LCesarAdvogados.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public virtual string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Usuario, LoginViewModel>();
            CreateMap<Posts, PostViewModel>();
        }
    }
}