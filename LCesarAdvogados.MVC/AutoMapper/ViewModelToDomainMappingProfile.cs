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

#pragma warning disable CS0672 // O membro substitui o membro obsoleto
        protected override void Configure()
#pragma warning restore CS0672 // O membro substitui o membro obsoleto
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Usuario, LoginViewModel>();
            CreateMap<Posts, PostViewModel>();
        }
    }
}