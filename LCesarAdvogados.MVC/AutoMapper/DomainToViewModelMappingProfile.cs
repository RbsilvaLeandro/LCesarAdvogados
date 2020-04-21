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

#pragma warning disable CS0672 // O membro substitui o membro obsoleto
        protected override void Configure()
#pragma warning restore CS0672 // O membro substitui o membro obsoleto
        {
           CreateMap<UsuarioViewModel, Usuario>();
           CreateMap<LoginViewModel, Usuario>();
           CreateMap<PostViewModel, Posts>();
        }
    }
}